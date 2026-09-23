# Minimum Operations to Reduce X to Zero

![Difficulty](https://img.shields.io/badge/Difficulty-Medium-yellow)

## Problem

You are given an integer array `nums` and an integer `x`. In one operation, you can either remove the leftmost or the rightmost element from the array `nums` and subtract its value from `x`. Note that this  **modifies**  the array for future operations.

Return  *the  **minimum number**  of operations to reduce* `x`  *to  **exactly***  `0`  *if it is possible**, otherwise, return* `-1`.

 

 **Example 1:** 

```
Input: nums = [1,1,4,2,3], x = 5
Output: 2
Explanation: The optimal solution is to remove the last two elements to reduce x to zero.

```

 **Example 2:** 

```
Input: nums = [5,6,7,8,9], x = 4
Output: -1

```

 **Example 3:** 

```
Input: nums = [3,2,20,1,1,3], x = 10
Output: 5
Explanation: The optimal solution is to remove the last three elements and the first two elements (5 operations in total) to reduce x to zero.

```

 

 **Constraints:** 

- 1 <= nums.length <= 105
- 1 <= nums[i] <= 104
- 1 <= x <= 109

## Solution

**Language:** Java  
**Runtime:** 4 ms (beats 98.07%)  
**Memory:** 101.9 MB (beats 76.11%)  
**Submitted:** 2026-09-23T17:17:57.919Z  

```java
class Solution {
    public int minOperations(int[] nums, int x) {

        int n = nums.length;

        // Calculate total sum
        int totalSum = 0;

        for (int num : nums) {
            totalSum += num;
        }

        // Sum of the subarray we want to keep
        int target = totalSum - x;

        // If target is negative, impossible
        if (target < 0) {
            return -1;
        }

        // If target is 0, remove everything
        if (target == 0) {
            return n;
        }

        int left = 0;
        int currentSum = 0;
        int maxLength = -1;

        for (int right = 0; right < n; right++) {

            currentSum += nums[right];

            // Shrink window if sum becomes too large
            while (currentSum > target) {
                currentSum -= nums[left];
                left++;
            }

            // Found a valid subarray
            if (currentSum == target) {
                maxLength = Math.max(
                    maxLength,
                    right - left + 1
                );
            }
        }

        // No valid subarray
        if (maxLength == -1) {
            return -1;
        }

        return n - maxLength;
    }
}
```

---

[View on LeetCode](https://leetcode.com/problems/minimum-operations-to-reduce-x-to-zero/)