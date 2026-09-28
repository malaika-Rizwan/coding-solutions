# Maximum Nesting Depth of the Parentheses

![Difficulty](https://img.shields.io/badge/Difficulty-Easy-green)

## Problem

Given a  **valid parentheses string**  `s`, return the  **nesting depth**  of `s`. The nesting depth is the  **maximum**  number of nested parentheses.

 

 **Example 1:** 

 **Input:**  s = "(1+(2*3)+((8)/4))+1"

 **Output:**  3

 **Explanation:** 

Digit 8 is inside of 3 nested parentheses in the string.

 **Example 2:** 

 **Input:**  s = "(1)+((2))+(((3)))"

 **Output:**  3

 **Explanation:** 

Digit 3 is inside of 3 nested parentheses in the string.

 **Example 3:** 

 **Input:**  s = "()(())((()()))"

 **Output:**  3

 

 **Constraints:** 

- 1 <= s.length <= 100
- s consists of digits 0-9 and characters '+', '-', '*', '/', '(', and ')'.
- It is guaranteed that parentheses expression s is a VPS.

## Solution

**Language:** C#  
**Runtime:** 0 ms (beats 100.00%)  
**Memory:** 38.3 MB (beats 93.75%)  
**Submitted:** 2026-09-28T16:56:02.348Z  

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

[View on LeetCode](https://leetcode.com/problems/maximum-nesting-depth-of-the-parentheses/)