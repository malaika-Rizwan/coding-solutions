# Longest Valid Parentheses

![Difficulty](https://img.shields.io/badge/Difficulty-Hard-red)

## Problem

Given a string containing just the characters `'('` and `')'`, return  *the length of the longest valid (well-formed) parentheses **substring*.

 

 **Example 1:** 

```
Input: s = "(()"
Output: 2
Explanation: The longest valid parentheses substring is "()".

```

 **Example 2:** 

```
Input: s = ")()())"
Output: 4
Explanation: The longest valid parentheses substring is "()()".

```

 **Example 3:** 

```
Input: s = ""
Output: 0

```

 

 **Constraints:** 

- 0 <= s.length <= 3 * 104
- s[i] is '(', or ')'.

## Solution

**Language:** Java  
**Runtime:** 5 ms (beats 76.17%)  
**Memory:** 46.7 MB (beats 26.12%)  
**Submitted:** 2026-09-24T16:51:44.164Z  

```java
class Solution {
    public int longestValidParentheses(String s) {

        Stack<Integer> stack = new Stack<>();

        // Base index before the valid substring starts
        stack.push(-1);

        int maxLength = 0;

        for (int i = 0; i < s.length(); i++) {

            if (s.charAt(i) == '(') {
                // Store the index of '('
                stack.push(i);
            } else {
                // Remove the matching '('
                stack.pop();

                if (stack.isEmpty()) {
                    // Current ')' cannot be matched
                    stack.push(i);
                } else {
                    // Calculate length of valid substring
                    int length = i - stack.peek();
                    maxLength = Math.max(maxLength, length);
                }
            }
        }

        return maxLength;
    }
}
```

---

[View on LeetCode](https://leetcode.com/problems/longest-valid-parentheses/)