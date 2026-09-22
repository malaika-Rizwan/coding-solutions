# Find X Value of Array II

![Difficulty](https://img.shields.io/badge/Difficulty-Hard-red)

## Problem

You are given an array of  **positive**  integers `nums` and a  **positive**  integer `k`. You are also given a 2D array `queries`, where `queries[i] = [indexi, valuei, starti, xi]`.

You are allowed to perform an operation  **once**  on `nums`, where you can remove any  **suffix**  from `nums` such that `nums` remains  **non-empty**.

The  **x-value**  of `nums`  **for a given**  `x` is defined as the number of ways to perform this operation so that the  **product**  of the remaining elements leaves a  *remainder*  of `x`  **modulo**  `k`.

For each query in `queries` you need to determine the  **x-value**  of `nums` for `xi` after performing the following actions:

- Update nums[indexi] to valuei. Only this step persists for the rest of the queries.
- Remove the prefix nums[0..(starti - 1)] (where nums[0..(-1)] will be used to represent the empty prefix).

Return an array `result` of size `queries.length` where `result[i]` is the answer for the `ith` query.

A  **prefix**  of an array is a subarray that starts from the beginning of the array and extends to any point within it.

A  **suffix**  of an array is a subarray that starts at any point within the array and extends to the end of the array.

 **Note**  that the prefix and suffix to be chosen for the operation can be  **empty**.

 **Note**  that x-value has a  *different*  definition in this version.

 

 **Example 1:** 

 **Input:**  nums = [1,2,3,4,5], k = 3, queries = [[2,2,0,2],[3,3,3,0],[0,1,0,1]]

 **Output:**  [2,2,2]

 **Explanation:** 

- For query 0, nums becomes [1, 2, 2, 4, 5], and the empty prefix must be removed. The possible operations are: Remove the suffix [2, 4, 5]. nums becomes [1, 2]. Remove the empty suffix. nums becomes [1, 2, 2, 4, 5] with a product 80, which gives remainder 2 when divided by 3.
- For query 1, nums becomes [1, 2, 2, 3, 5], and the prefix [1, 2, 2] must be removed. The possible operations are: Remove the empty suffix. nums becomes [3, 5]. Remove the suffix [5]. nums becomes [3].
- For query 2, nums becomes [1, 2, 2, 3, 5], and the empty prefix must be removed. The possible operations are: Remove the suffix [2, 2, 3, 5]. nums becomes [1]. Remove the suffix [3, 5]. nums becomes [1, 2, 2].

 **Example 2:** 

 **Input:**  nums = [1,2,4,8,16,32], k = 4, queries = [[0,2,0,2],[0,2,0,1]]

 **Output:**  [1,0]

 **Explanation:** 

- For query 0, nums becomes [2, 2, 4, 8, 16, 32]. The only possible operation is: Remove the suffix [2, 4, 8, 16, 32].
- For query 1, nums becomes [2, 2, 4, 8, 16, 32]. There is no possible way to perform the operation.

 **Example 3:** 

 **Input:**  nums = [1,1,2,1,1], k = 2, queries = [[2,1,0,1]]

 **Output:**  [5]

 

 **Constraints:** 

- 1 <= nums[i] <= 109
- 1 <= nums.length <= 105
- 1 <= k <= 5
- 1 <= queries.length <= 2 * 104
- queries[i] == [indexi, valuei, starti, xi]
- 0 <= indexi <= nums.length - 1
- 1 <= valuei <= 109
- 0 <= starti <= nums.length - 1
- 0 <= xi <= k - 1

## Solution

**Language:** Java  
**Runtime:** 248 ms (beats 52.63%)  
**Memory:** 285.8 MB (beats 26.32%)  
**Submitted:** 2026-09-22T15:17:42.791Z  

```java
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
```

---

[View on LeetCode](https://leetcode.com/problems/find-x-value-of-array-ii/)