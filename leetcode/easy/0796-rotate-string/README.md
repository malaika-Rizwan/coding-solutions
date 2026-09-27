# Rotate String

![Difficulty](https://img.shields.io/badge/Difficulty-Easy-green)

## Problem

Given two strings `s` and `goal`, return `true`  *if and only if*  `s`  *can become*  `goal`  *after some number of  **shifts**  on*  `s`.

A  **shift**  on `s` consists of moving the leftmost character of `s` to the rightmost position.

- For example, if s = "abcde", then it will be "bcdea" after one shift.

 

 **Example 1:** 

```
Input: s = "abcde", goal = "cdeab"
Output: true

```

 **Example 2:** 

```
Input: s = "abcde", goal = "abced"
Output: false

```

 

 **Constraints:** 

- 1 <= s.length, goal.length <= 100
- s and goal consist of lowercase English letters.

## Solution

**Language:** C#  
**Runtime:** 0 ms (beats 100.00%)  
**Memory:** 42.7 MB (beats 79.05%)  
**Submitted:** 2026-09-27T17:22:47.898Z  

```cs
public class Solution
{
    public bool RotateString(string s, string goal)
    {
        if (s.Length != goal.Length)
        {
            return false;
        }

        string combined = s + s;

        return combined.Contains(goal);
    }
}
```

---

[View on LeetCode](https://leetcode.com/problems/rotate-string/)