# Remove Outermost Parentheses

![Difficulty](https://img.shields.io/badge/Difficulty-Easy-green)

## Problem

A valid parentheses string is either empty `""`, `"(" + A + ")"`, or `A + B`, where `A` and `B` are valid parentheses strings, and `+` represents string concatenation.

- For example, "", "()", "(())()", and "(()(()))" are all valid parentheses strings.

A valid parentheses string `s` is primitive if it is nonempty, and there does not exist a way to split it into `s = A + B`, with `A` and `B` nonempty valid parentheses strings.

Given a valid parentheses string `s`, consider its primitive decomposition: `s = P1 + P2 +... + Pk`, where `Pi` are primitive valid parentheses strings.

Return `s`  *after removing the outermost parentheses of every primitive string in the primitive decomposition of* `s`.

 

 **Example 1:** 

```
Input: s = "(()())(())"
Output: "()()()"
Explanation: 
The input string is "(()())(())", with primitive decomposition "(()())" + "(())".
After removing outer parentheses of each part, this is "()()" + "()" = "()()()".

```

 **Example 2:** 

```
Input: s = "(()())(())(()(()))"
Output: "()()()()(())"
Explanation: 
The input string is "(()())(())(()(()))", with primitive decomposition "(()())" + "(())" + "(()(()))".
After removing outer parentheses of each part, this is "()()" + "()" + "()(())" = "()()()()(())".

```

 **Example 3:** 

```
Input: s = "()()"
Output: ""
Explanation: 
The input string is "()()", with primitive decomposition "()" + "()".
After removing outer parentheses of each part, this is "" + "" = "".

```

 

 **Constraints:** 

- 1 <= s.length <= 105
- s[i] is either '(' or ')'.
- s is a valid parentheses string.

## Solution

**Language:** C#  
**Runtime:** 1 ms (beats 99.25%)  
**Memory:** 41.4 MB (beats 58.96%)  
**Submitted:** 2026-10-08T14:41:50.588Z  

```cs
public class Solution
{
    public string RemoveOuterParentheses(string s)
    {
        StringBuilder result = new StringBuilder();
        int depth = 0;

        foreach (char c in s)
        {
            if (c == '(')
            {
                // If depth > 0, this is NOT an outermost '('
                if (depth > 0)
                {
                    result.Append(c);
                }

                depth++;
            }
            else
            {
                depth--;

                // If depth > 0, this is NOT an outermost ')'
                if (depth > 0)
                {
                    result.Append(c);
                }
            }
        }

        return result.ToString();
    }
}
```

---

[View on LeetCode](https://leetcode.com/problems/remove-outermost-parentheses/)