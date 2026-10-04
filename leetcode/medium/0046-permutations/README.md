# Permutations

![Difficulty](https://img.shields.io/badge/Difficulty-Medium-yellow)

## Problem

Given an array `nums` of distinct integers, return all the possible permutations. You can return the answer in  **any order**.

 

 **Example 1:** 

```
Input: nums = [1,2,3]
Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]

```

 **Example 2:** 

```
Input: nums = [0,1]
Output: [[0,1],[1,0]]

```

 **Example 3:** 

```
Input: nums = [1]
Output: [[1]]

```

 

 **Constraints:** 

- 1 <= nums.length <= 6
- -10 <= nums[i] <= 10
- All the integers of nums are unique.

## Solution

**Language:** C#  
**Runtime:** 0 ms (beats 100.00%)  
**Memory:** 47.9 MB (beats 22.11%)  
**Submitted:** 2026-10-04T16:00:30.268Z  

```cs
public class Solution
{
    public IList<IList<int>> Permute(int[] nums)
    {
        List<IList<int>> result = new List<IList<int>>();
        List<int> current = new List<int>();
        bool[] used = new bool[nums.Length];

        Backtrack(nums, current, used, result);

        return result;
    }

    private void Backtrack(
        int[] nums,
        List<int> current,
        bool[] used,
        List<IList<int>> result)
    {
        // We have created one complete permutation
        if (current.Count == nums.Length)
        {
            result.Add(new List<int>(current));
            return;
        }

        // Try every number
        for (int i = 0; i < nums.Length; i++)
        {
            // Skip numbers already used
            if (used[i])
                continue;

            // Choose
            current.Add(nums[i]);
            used[i] = true;

            // Explore
            Backtrack(nums, current, used, result);

            // Undo
            current.RemoveAt(current.Count - 1);
            used[i] = false;
        }
    }
}
```

---

[View on LeetCode](https://leetcode.com/problems/permutations/)