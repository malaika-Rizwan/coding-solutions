# Reverse Substrings Between Each Pair of Parentheses

![Difficulty](https://img.shields.io/badge/Difficulty-Medium-yellow)

## Problem

You are given a string `s` that consists of lower case English letters and brackets.

Reverse the strings in each pair of matching parentheses, starting from the innermost one.

Your result should  **not**  contain any brackets.

 

 **Example 1:** 

```
Input: s = "(abcd)"
Output: "dcba"

```

 **Example 2:** 

```
Input: s = "(u(love)i)"
Output: "iloveu"
Explanation: The substring "love" is reversed first, then the whole string is reversed.

```

 **Example 3:** 

```
Input: s = "(ed(et(oc))el)"
Output: "leetcode"
Explanation: First, we reverse the substring "oc", then "etco", and finally, the whole string.

```

 

 **Constraints:** 

- 1 <= s.length <= 2000
- s only contains lower case English characters and parentheses.
- It is guaranteed that all parentheses are balanced.

## Solution

**Language:** C#  
**Runtime:** 4 ms (beats 70.00%)  
**Memory:** 41.2 MB (beats 70.00%)  
**Submitted:** 2026-09-27T17:17:28.140Z  

```cs
public class Solution
{
    public string ReverseParentheses(string s)
    {
        Stack<StringBuilder> stack = new Stack<StringBuilder>();

        StringBuilder current = new StringBuilder();

        foreach (char ch in s)
        {
            if (ch == '(')
            {
                // Save the current string
                stack.Push(current);

                // Start a new string
                current = new StringBuilder();
            }
            else if (ch == ')')
            {
                // Reverse the substring inside parentheses
                Reverse(current);

                // Get the string before '('
                StringBuilder previous = stack.Pop();

                // Add reversed substring to previous string
                previous.Append(current);

                current = previous;
            }
            else
            {
                // Add normal character
                current.Append(ch);
            }
        }

        return current.ToString();
    }

    private void Reverse(StringBuilder sb)
    {
        int left = 0;
        int right = sb.Length - 1;

        while (left < right)
        {
            char temp = sb[left];
            sb[left] = sb[right];
            sb[right] = temp;

            left++;
            right--;
        }
    }
}
```

---

[View on LeetCode](https://leetcode.com/problems/reverse-substrings-between-each-pair-of-parentheses/)