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
**Runtime:** 3 ms (beats 80.00%)  
**Memory:** 41.2 MB (beats 70.00%)  
**Submitted:** 2026-09-28T16:57:46.327Z  

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

[View on LeetCode](https://leetcode.com/problems/maximum-nesting-depth-of-the-parentheses/)