# Minimum Jumps to Reach End via Prime Teleportation

![Difficulty](https://img.shields.io/badge/Difficulty-Medium-yellow)

## Problem

You are given an integer array `nums` of length `n`.

You start at index 0, and your goal is to reach index `n - 1`.

From any index `i`, you may perform one of the following operations:

- Adjacent Step: Jump to index i + 1 or i - 1, if the index is within bounds.
- Prime Teleportation: If nums[i] is a prime number p, you may instantly jump to any index j != i such that nums[j] % p == 0.

Return the  **minimum**  number of jumps required to reach index `n - 1`.

 

 **Example 1:** 

 **Input:**  nums = [1,2,4,6]

 **Output:**  2

 **Explanation:** 

One optimal sequence of jumps is:

- Start at index i = 0. Take an adjacent step to index 1.
- At index i = 1, nums[1] = 2 is a prime number. Therefore, we teleport to index i = 3 as nums[3] = 6 is divisible by 2.

Thus, the answer is 2.

 **Example 2:** 

 **Input:**  nums = [2,3,4,7,9]

 **Output:**  2

 **Explanation:** 

One optimal sequence of jumps is:

- Start at index i = 0. Take an adjacent step to index i = 1.
- At index i = 1, nums[1] = 3 is a prime number. Therefore, we teleport to index i = 4 since nums[4] = 9 is divisible by 3.

Thus, the answer is 2.

 **Example 3:** 

 **Input:**  nums = [4,6,5,8]

 **Output:**  3

 **Explanation:** 

- Since no teleportation is possible, we move through 0 → 1 → 2 → 3. Thus, the answer is 3.

 

 **Constraints:** 

- 1 <= n == nums.length <= 105
- 1 <= nums[i] <= 106

## Solution

**Language:** Java  
**Runtime:** 271 ms (beats 53.03%)  
**Memory:** 183.5 MB (beats 73.86%)  
**Submitted:** 2026-10-01T16:36:21.592Z  

```java
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
```

---

[View on LeetCode](https://leetcode.com/problems/minimum-jumps-to-reach-end-via-prime-teleportation/)