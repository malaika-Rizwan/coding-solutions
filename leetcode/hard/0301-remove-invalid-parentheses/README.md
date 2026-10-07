# Remove Invalid Parentheses

![Difficulty](https://img.shields.io/badge/Difficulty-Hard-red)

## Problem

Given a string `s` that contains parentheses and letters, remove the minimum number of invalid parentheses to make the input string valid.

Return  *a list of  **unique strings**  that are valid with the minimum number of removals*. You may return the answer in  **any order**.

 

 **Example 1:** 

```
Input: s = "()())()"
Output: ["(())()","()()()"]

```

 **Example 2:** 

```
Input: s = "(a)())()"
Output: ["(a())()","(a)()()"]

```

 **Example 3:** 

```
Input: s = ")("
Output: [""]

```

 

 **Constraints:** 

- 1 <= s.length <= 25
- s consists of lowercase English letters and parentheses '(' and ')'.
- There will be at most 20 parentheses in s.

## Solution

**Language:** C#  
**Runtime:** 245 ms (beats 7.69%)  
**Memory:** 62.6 MB (beats 41.03%)  
**Submitted:** 2026-10-07T17:33:03.737Z  

```cs
public class Solution
{
    private HashSet<string> result = new HashSet<string>();

    public IList<string> RemoveInvalidParentheses(string s)
    {
        int leftRemove = 0;
        int rightRemove = 0;

        // Find how many '(' and ')' need to be removed
        foreach (char c in s)
        {
            if (c == '(')
            {
                leftRemove++;
            }
            else if (c == ')')
            {
                if (leftRemove > 0)
                {
                    leftRemove--;
                }
                else
                {
                    rightRemove++;
                }
            }
        }

        Backtrack(s, 0, 0, leftRemove, rightRemove, "");

        return new List<string>(result);
    }

    private void Backtrack(
        string s,
        int index,
        int balance,
        int leftRemove,
        int rightRemove,
        string current)
    {
        // Invalid balance
        if (balance < 0)
            return;

        // End of string
        if (index == s.Length)
        {
            if (balance == 0 && leftRemove == 0 && rightRemove == 0)
            {
                result.Add(current);
            }

            return;
        }

        char c = s[index];

        // Option 1: Remove current parenthesis
        if (c == '(' && leftRemove > 0)
        {
            Backtrack(
                s,
                index + 1,
                balance,
                leftRemove - 1,
                rightRemove,
                current
            );
        }

        if (c == ')' && rightRemove > 0)
        {
            Backtrack(
                s,
                index + 1,
                balance,
                leftRemove,
                rightRemove - 1,
                current
            );
        }

        // Option 2: Keep current character
        if (c == '(')
        {
            Backtrack(
                s,
                index + 1,
                balance + 1,
                leftRemove,
                rightRemove,
                current + c
            );
        }
        else if (c == ')')
        {
            Backtrack(
                s,
                index + 1,
                balance - 1,
                leftRemove,
                rightRemove,
                current + c
            );
        }
        else
        {
            // Letter
            Backtrack(
                s,
                index + 1,
                balance,
                leftRemove,
                rightRemove,
                current + c
            );
        }
    }
}
```

---

[View on LeetCode](https://leetcode.com/problems/remove-invalid-parentheses/)