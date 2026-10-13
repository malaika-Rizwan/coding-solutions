# Jump Game III

![Difficulty](https://img.shields.io/badge/Difficulty-Medium-yellow)

## Problem

Given an array of non-negative integers `arr`, you are initially positioned at `start` index of the array. When you are at index `i`, you can jump to `i + arr[i]` or `i - arr[i]`, check if you can reach  **any**  index with value 0.

Notice that you can not jump outside of the array at any time.

 

 **Example 1:** 

```
Input: arr = [4,2,3,0,3,1,2], start = 5
Output: true
Explanation: 
All possible ways to reach at index 3 with value 0 are: 
index 5 -> index 4 -> index 1 -> index 3 
index 5 -> index 6 -> index 4 -> index 1 -> index 3 

```

 **Example 2:** 

```
Input: arr = [4,2,3,0,3,1,2], start = 0
Output: true 
Explanation: 
One possible way to reach at index 3 with value 0 is: 
index 0 -> index 4 -> index 1 -> index 3

```

 **Example 3:** 

```
Input: arr = [3,0,2,1,2], start = 2
Output: false
Explanation: There is no way to reach at index 1 with value 0.

```

 

 **Constraints:** 

- 1 <= arr.length <= 5 * 104
- 0 <= arr[i] < arr.length
- 0 <= start < arr.length

## Solution

**Language:** C#  
**Runtime:** 0 ms (beats 100.00%)  
**Memory:** 51.6 MB (beats 89.66%)  
**Submitted:** 2026-10-13T17:43:01.801Z  

```cs

public class Solution
{
    public bool CanReach(int[] arr, int start)
    {
        bool[] visited = new bool[arr.Length];

        return DFS(arr, start, visited);
    }

    private bool DFS(int[] arr, int index, bool[] visited)
    {
        // Check array boundaries
        if (index < 0 || index >= arr.Length)
            return false;

        // Avoid visiting the same index repeatedly
        if (visited[index])
            return false;

        // Found zero
        if (arr[index] == 0)
            return true;

        visited[index] = true;

        // Try jumping right or left
        return DFS(arr, index + arr[index], visited) ||
               DFS(arr, index - arr[index], visited);
    }
}

```

---

[View on LeetCode](https://leetcode.com/problems/jump-game-iii/)