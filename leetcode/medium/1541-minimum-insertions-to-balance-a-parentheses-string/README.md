# Minimum Insertions to Balance a Parentheses String

![Difficulty](https://img.shields.io/badge/Difficulty-Medium-yellow)

## Problem

Given a parentheses string `s` containing only the characters `'('` and `')'`. A parentheses string is  **balanced**  if:

- Any left parenthesis '(' must have a corresponding two consecutive right parenthesis '))'.
- Left parenthesis '(' must go before the corresponding two consecutive right parenthesis '))'.

In other words, we treat `'('` as an opening parenthesis and `'))'` as a closing parenthesis.

- For example, "())", "())(())))" and "(())())))" are balanced, ")()", "()))" and "(()))" are not balanced.

You can insert the characters `'('` and `')'` at any position of the string to balance it if needed.

Return  *the minimum number of insertions*  needed to make `s` balanced.

 

 **Example 1:** 

```
Input: s = "(()))"
Output: 1
Explanation: The second '(' has two matching '))', but the first '(' has only ')' matching. We need to add one more ')' at the end of the string to be "(())))" which is balanced.

```

 **Example 2:** 

```
Input: s = "())"
Output: 0
Explanation: The string is already balanced.

```

 **Example 3:** 

```
Input: s = "))())("
Output: 3
Explanation: Add '(' to match the first '))', Add '))' to match the last '('.

```

 

 **Constraints:** 

- 1 <= s.length <= 105
- s consists of '(' and ')' only.

## Solution

**Language:** C#  
**Runtime:** 9 ms  
**Memory:** 45.9 MB (beats 100.00%)  
**Submitted:** 2026-10-09T17:22:50.335Z  

```cs

public class Solution
{
    public int MinInsertions(string s)
    {
        int open = 0;
        int insertions = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(')
            {
                open++;
            }
            else
            {
                // If the next character is not ')',
                // insert one ')' to complete the pair.
                if (i + 1 < s.Length && s[i + 1] == ')')
                {
                    i++;
                }
                else
                {
                    insertions++;
                }

                // Match this pair with an opening '('.
                if (open > 0)
                {
                    open--;
                }
                else
                {
                    // Insert a missing opening '('.
                    insertions++;
                }
            }
        }

        // Each unmatched '(' needs two closing ')'.
        insertions += open * 2;

        return insertions;
    }
}
```

---

[View on LeetCode](https://leetcode.com/problems/minimum-insertions-to-balance-a-parentheses-string/)