# Combination Sum II

![Difficulty](https://img.shields.io/badge/Difficulty-Medium-yellow)

## Problem

Given a collection of candidate numbers (`candidates`) and a target number (`target`), find all unique combinations in `candidates` where the candidate numbers sum to `target`.

Each number in `candidates` may only be used  **once**  in the combination.

 **Note:**  The solution set must not contain duplicate combinations.

 

 **Example 1:** 

```
Input: candidates = [10,1,2,7,6,1,5], target = 8
Output: 
[
[1,1,6],
[1,2,5],
[1,7],
[2,6]
]

```

 **Example 2:** 

```
Input: candidates = [2,5,2,1,2], target = 5
Output: 
[
[1,2,2],
[5]
]

```

 

 **Constraints:** 

- 1 <= candidates.length <= 100
- 1 <= candidates[i] <= 50
- 1 <= target <= 30

## Solution

**Language:** C#  
**Runtime:** 6 ms (beats 51.46%)  
**Memory:** 47.1 MB (beats 85.11%)  
**Submitted:** 2026-09-25T16:44:05.559Z  

```cs
public class Solution
{
    public IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        List<IList<int>> result = new List<IList<int>>();
        List<int> current = new List<int>();

        Array.Sort(candidates);

        Backtrack(candidates, target, 0, current, result);

        return result;
    }

    private void Backtrack(
        int[] candidates,
        int remaining,
        int start,
        List<int> current,
        List<IList<int>> result)
    {
        // Target reached
        if (remaining == 0)
        {
            result.Add(new List<int>(current));
            return;
        }

        for (int i = start; i < candidates.Length; i++)
        {
            // Skip duplicate values at the same level
            if (i > start && candidates[i] == candidates[i - 1])
                continue;

            // Since array is sorted
            if (candidates[i] > remaining)
                break;

            // Choose
            current.Add(candidates[i]);

            // i + 1 because each element can only be used once
            Backtrack(
                candidates,
                remaining - candidates[i],
                i + 1,
                current,
                result
            );

            // Undo choice
            current.RemoveAt(current.Count - 1);
        }
    }
}
```

---

[View on LeetCode](https://leetcode.com/problems/combination-sum-ii/)