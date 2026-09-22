class Solution {

    static class Node {
        int prod;
        int[] pref;

        Node(int k) {
            pref = new int[k];
            prod = 1 % k;
        }
    }

    int n, k;
    int[] nums;
    Node[] tree;

    private Node merge(Node left, Node right) {
        Node res = new Node(k);

        // Product of the complete segment
        res.prod = (left.prod * right.prod) % k;

        // Prefixes completely inside left
        for (int r = 0; r < k; r++) {
            res.pref[r] += left.pref[r];
        }

        // Prefixes that start in left and continue into right
        for (int a = 0; a < k; a++) {
            if (left.pref[a] == 0) continue;

            for (int b = 0; b < k; b++) {
                if (right.pref[b] == 0) continue;

                int rem = (a * b) % k;
                res.pref[rem] += right.pref[b];
            }
        }

        /*
         * The above multiplication using left prefix remainder is
         * not sufficient because a prefix entering right must contain
         * the ENTIRE left segment, not an arbitrary left prefix.
         *
         * Therefore we rebuild the cross contribution below.
         */

        // Remove the incorrectly added cross contribution.
        for (int r = 0; r < k; r++) {
            res.pref[r] -= 0;
        }

        return res;
    }

    private Node combine(Node left, Node right) {
        Node res = new Node(k);

        // Entire segment product
        res.prod = (left.prod * right.prod) % k;

        // Prefixes ending inside left
        for (int r = 0; r < k; r++) {
            res.pref[r] = left.pref[r];
        }

        // Prefixes that contain all of left and then part of right
        for (int r = 0; r < k; r++) {
            int newRem = (left.prod * r) % k;
            res.pref[newRem] += right.pref[r];
        }

        return res;
    }

    private void build(int node, int l, int r) {
        if (l == r) {
            tree[node] = new Node(k);

            int rem = nums[l] % k;

            tree[node].prod = rem;
            tree[node].pref[rem] = 1;

            return;
        }

        int mid = (l + r) / 2;

        build(node * 2, l, mid);
        build(node * 2 + 1, mid + 1, r);

        tree[node] = combine(tree[node * 2], tree[node * 2 + 1]);
    }

    private void update(int node, int l, int r, int index, int value) {
        if (l == r) {
            tree[node] = new Node(k);

            int rem = value % k;

            tree[node].prod = rem;
            tree[node].pref[rem] = 1;

            return;
        }

        int mid = (l + r) / 2;

        if (index <= mid) {
            update(node * 2, l, mid, index, value);
        } else {
            update(node * 2 + 1, mid + 1, r, index, value);
        }

        tree[node] = combine(tree[node * 2], tree[node * 2 + 1]);
    }

    private Node query(int node, int l, int r, int ql, int qr) {
        if (ql <= l && r <= qr) {
            return tree[node];
        }

        int mid = (l + r) / 2;

        if (qr <= mid) {
            return query(node * 2, l, mid, ql, qr);
        }

        if (ql > mid) {
            return query(node * 2 + 1, mid + 1, r, ql, qr);
        }

        Node left = query(node * 2, l, mid, ql, qr);
        Node right = query(node * 2 + 1, mid + 1, r, ql, qr);

        return combine(left, right);
    }

    public int[] resultArray(int[] nums, int k, int[][] queries) {
        this.nums = nums;
        this.n = nums.length;
        this.k = k;

        tree = new Node[4 * n];

        build(1, 0, n - 1);

        int[] result = new int[queries.length];

        for (int i = 0; i < queries.length; i++) {
            int index = queries[i][0];
            int value = queries[i][1];
            int start = queries[i][2];
            int x = queries[i][3];

            // Persistent update
            nums[index] = value;
            update(1, 0, n - 1, index, value);

            // Query [start, n-1]
            Node res = query(1, 0, n - 1, start, n - 1);

            result[i] = res.pref[x];
        }

        return result;
    }
}