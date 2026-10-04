# Valid Parenthesis String

![Difficulty](https://img.shields.io/badge/Difficulty-Medium-yellow)

## Problem

Given a string `s` containing only three types of characters: `'('`, `')'` and `' *'`, return `true`* if *`s`* is  **valid** *.

The following rules define a  **valid**  string:

- Any left parenthesis '(' must have a corresponding right parenthesis ')'.
- Any right parenthesis ')' must have a corresponding left parenthesis '('.
- Left parenthesis '(' must go before the corresponding right parenthesis ')'.
- '*' could be treated as a single right parenthesis ')' or a single left parenthesis '(' or an empty string "".

 

 **Example 1:** 

```
Input: s = "()"
Output: true

```

 **Example 2:** 

```
Input: s = "(*)"
Output: true

```

 **Example 3:** 

```
Input: s = "(*))"
Output: true

```

 **Example 4:** 

```
Input: s = "("
Output: false

```

 

 **Constraints:** 

- 1 <= s.length <= 100
- s[i] is '(', ')' or '*'.

## Solution

**Language:** C#  
**Runtime:** 0 ms (beats 100.00%)  
**Memory:** 40.4 MB (beats 71.67%)  
**Submitted:** 2026-10-04T15:34:03.174Z  

```cs
public class Solution
{
    public bool CheckValidString(string s)
    {
        int minOpen = 0;
        int maxOpen = 0;

        foreach (char c in s)
        {
            if (c == '(')
            {
                minOpen++;
                maxOpen++;
            }
            else if (c == ')')
            {
                minOpen--;
                maxOpen--;
            }
            else // '*'
            {
                minOpen--;
                maxOpen++;
            }

            // We cannot have negative possible open brackets
            if (maxOpen < 0)
            {
                return false;
            }

            minOpen = Math.Max(0, minOpen);
        }

        return minOpen == 0;
    }
}
```

---

[View on LeetCode](https://leetcode.com/problems/valid-parenthesis-string/)