import java.util.*;

class Solution {
    public int minJumps(int[] nums) {
        int n = nums.length;

        if (n == 1) {
            return 0;
        }

        // Find maximum value in nums
        int max = 0;
        for (int num : nums) {
            max = Math.max(max, num);
        }

        // smallest prime factor
        int[] spf = new int[max + 1];

        for (int i = 2; i <= max; i++) {
            if (spf[i] == 0) {
                spf[i] = i;

                if ((long) i * i <= max) {
                    for (int j = i * i; j <= max; j += i) {
                        if (spf[j] == 0) {
                            spf[j] = i;
                        }
                    }
                }
            }
        }

        // prime -> indices whose values are divisible by that prime
        Map<Integer, List<Integer>> primeToIndices = new HashMap<>();

        for (int i = 0; i < n; i++) {
            int x = nums[i];

            while (x > 1) {
                int prime = spf[x];

                primeToIndices
                    .computeIfAbsent(prime, k -> new ArrayList<>())
                    .add(i);

                // Remove all occurrences of this prime
                while (x % prime == 0) {
                    x /= prime;
                }
            }
        }

        // BFS
        Queue<Integer> queue = new LinkedList<>();
        boolean[] visited = new boolean[n];

        // We only process each prime teleport once
        boolean[] usedPrime = new boolean[max + 1];

        queue.offer(0);
        visited[0] = true;

        int steps = 0;

        while (!queue.isEmpty()) {

            int size = queue.size();

            while (size-- > 0) {

                int i = queue.poll();

                // Reached the destination
                if (i == n - 1) {
                    return steps;
                }

                // Move left
                if (i - 1 >= 0 && !visited[i - 1]) {
                    visited[i - 1] = true;
                    queue.offer(i - 1);
                }

                // Move right
                if (i + 1 < n && !visited[i + 1]) {
                    visited[i + 1] = true;
                    queue.offer(i + 1);
                }

                // Prime teleportation
                int value = nums[i];

                // value itself must be prime
                if (value >= 2 &&
                    spf[value] == value &&
                    !usedPrime[value]) {

                    usedPrime[value] = true;

                    List<Integer> indices = primeToIndices.get(value);

                    if (indices != null) {
                        for (int j : indices) {

                            if (!visited[j]) {
                                visited[j] = true;
                                queue.offer(j);
                            }
                        }
                    }
                }
            }

            steps++;
        }

        return -1;
    }
}