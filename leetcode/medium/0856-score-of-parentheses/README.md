# Score of Parentheses

![Difficulty](https://img.shields.io/badge/Difficulty-Medium-yellow)

## Problem

Given a balanced parentheses string `s`, return  *the  **score**  of the string*.

The  **score**  of a balanced parentheses string is based on the following rule:

- "()" has score 1.
- AB has score A + B, where A and B are balanced parentheses strings.
- (A) has score 2 * A, where A is a balanced parentheses string.

 

 **Example 1:** 

```
Input: s = "()"
Output: 1

```

 **Example 2:** 

```
Input: s = "(())"
Output: 2

```

 **Example 3:** 

```
Input: s = "()()"
Output: 2

```

 

 **Constraints:** 

- 2 <= s.length <= 50
- s consists of only '(' and ')'.
- s is a balanced parentheses string.

## Solution

**Language:** C#  
**Runtime:** 1 ms (beats 64.71%)  
**Memory:** 38.6 MB (beats 52.94%)  
**Submitted:** 2026-10-05T14:33:14.792Z  

```cs
public class Solution
{
    public int ScoreOfParentheses(string s)
    {
        Stack<int> stack = new Stack<int>();
        stack.Push(0);

        foreach (char c in s)
        {
            if (c == '(')
            {
                // Start a new level
                stack.Push(0);
            }
            else
            {
                // Get the score inside the current parentheses
                int innerScore = stack.Pop();

                // () = 1
                // (A) = 2 * A
                int score = innerScore == 0 ? 1 : 2 * innerScore;

                // Add this score to the outer level
                stack.Push(stack.Pop() + score);
            }
        }

        return stack.Pop();
    }
}
```

---

[View on LeetCode](https://leetcode.com/problems/score-of-parentheses/)