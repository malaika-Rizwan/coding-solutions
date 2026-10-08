# Minimum Moves to Make Array Complementary

![Difficulty](https://img.shields.io/badge/Difficulty-Medium-yellow)

## Problem

You are given an integer array `nums` of  **even**  length `n` and an integer `limit`. In one move, you can replace any integer from `nums` with another integer between `1` and `limit`, inclusive.

The array `nums` is  **complementary**  if for all indices `i` (**0-indexed**), `nums[i] + nums[n - 1 - i]` equals the same number. For example, the array `[1,2,3,4]` is complementary because for all indices `i`, `nums[i] + nums[n - 1 - i] = 5`.

Return the  ***minimum**  number of moves required to make  *`nums`*   **complementary** *.

 

 **Example 1:** 

```
Input: nums = [1,2,4,3], limit = 4
Output: 1
Explanation: In 1 move, you can change nums to [1,2,2,3] (underlined elements are changed).
nums[0] + nums[3] = 1 + 3 = 4.
nums[1] + nums[2] = 2 + 2 = 4.
nums[2] + nums[1] = 2 + 2 = 4.
nums[3] + nums[0] = 3 + 1 = 4.
Therefore, nums[i] + nums[n-1-i] = 4 for every i, so nums is complementary.

```

 **Example 2:** 

```
Input: nums = [1,2,2,1], limit = 2
Output: 2
Explanation: In 2 moves, you can change nums to [2,2,2,2]. You cannot change any number to 3 since 3 > limit.

```

 **Example 3:** 

```
Input: nums = [1,2,1,2], limit = 2
Output: 0
Explanation: nums is already complementary.

```

 

 **Constraints:** 

- n == nums.length
- 2 <= n <= 105
- 1 <= nums[i] <= limit <= 105
- n is even.

## Solution

**Language:** C#  
**Runtime:** 0 ms  
**Memory:** 41.2 MB  
**Submitted:** 2026-10-08T14:47:31.042Z  

```cs
public class Solution
{
    public int MinMoves(int[] nums, int limit)
    {
        int[] diff = new int[2 * limit + 2];

        for (int i = 0; i < nums.Length / 2; i++)
        {
            int a = Math.Min(nums[i], nums[nums.Length - 1 - i]);
            int b = Math.Max(nums[i], nums[nums.Length - 1 - i]);

            int sum = a + b;

            // Initially: 2 moves for every possible sum
            diff[2] += 2;

            // From a + 1, we only need 1 move
            diff[a + 1] -= 1;

            // At the current sum, we need 0 moves
            diff[sum] -= 1;

            // After the current sum, we need 1 move again
            diff[sum + 1] += 1;

            // After b + limit, we need 2 moves again
            diff[b + limit + 1] -= 1;
        }

        int answer = nums.Length;
        int moves = 0;

        // Calculate actual number of moves for every target sum
        for (int target = 2; target <= 2 * limit; target++)
        {
            moves += diff[target];
            answer = Math.Min(answer, moves);
        }

        return answer;
    }
}
```

---

[View on LeetCode](https://leetcode.com/problems/minimum-moves-to-make-array-complementary/)