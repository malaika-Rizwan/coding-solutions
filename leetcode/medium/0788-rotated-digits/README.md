# Rotated Digits

![Difficulty](https://img.shields.io/badge/Difficulty-Medium-yellow)

## Problem

An integer `x` is a  **good**  if after rotating each digit individually by 180 degrees, we get a valid number that is different from `x`. Each digit must be rotated - we cannot choose to leave it alone.

A number is valid if each digit remains a digit after rotation. For example:

- 0, 1, and 8 rotate to themselves,
- 2 and 5 rotate to each other (in this case they are rotated in a different direction, in other words, 2 or 5 gets mirrored),
- 6 and 9 rotate to each other, and
- the rest of the numbers do not rotate to any other number and become invalid.

Given an integer `n`, return  *the number of  **good**  integers in the range* `[1, n]`.

 

 **Example 1:** 

```
Input: n = 10
Output: 4
Explanation: There are four good numbers in the range [1, 10] : 2, 5, 6, 9.
Note that 1 and 10 are not good numbers, since they remain unchanged after rotating.

```

 **Example 2:** 

```
Input: n = 1
Output: 0

```

 **Example 3:** 

```
Input: n = 2
Output: 1

```

 

 **Constraints:** 

- 1 <= n <= 104

## Solution

**Language:** C#  
**Runtime:** 0 ms (beats 100.00%)  
**Memory:** 38.8 MB (beats 42.50%)  
**Submitted:** 2026-09-28T16:58:31.245Z  

```cs
public class Solution
{
    public int MaxDepth(string s)
    {
        int depth = 0;
        int maxDepth = 0;

        foreach (char c in s)
        {
            if (c == '(')
            {
                depth++;
                maxDepth = Math.Max(maxDepth, depth);
            }
            else if (c == ')')
            {
                depth--;
            }
        }

        return maxDepth;
    }
}
```

---

[View on LeetCode](https://leetcode.com/problems/rotated-digits/)