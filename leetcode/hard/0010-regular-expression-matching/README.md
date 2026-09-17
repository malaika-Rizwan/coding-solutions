# Regular Expression Matching

![Difficulty](https://img.shields.io/badge/Difficulty-Hard-red)

## Problem

Given an input string `s` and a pattern `p`, implement regular expression matching with support for `'.'` and `'*'` where:

- '.' Matches any single character.​​​​
- '*' Matches zero or more of the preceding element.

Return a boolean indicating whether the matching covers the entire input string (not partial).

 

 **Example 1:** 

```
Input: s = "aa", p = "a"
Output: false
Explanation: "a" does not match the entire string "aa".

```

 **Example 2:** 

```
Input: s = "aa", p = "a*"
Output: true
Explanation: '*' means zero or more of the preceding element, 'a'. Therefore, by repeating 'a' once, it becomes "aa".

```

 **Example 3:** 

```
Input: s = "ab", p = ".*"
Output: true
Explanation: ". *" means "zero or more (*) of any character (.)".

```

 

 **Constraints:** 

- 1 <= s.length <= 20
- 1 <= p.length <= 20
- s contains only lowercase English letters.
- p contains only lowercase English letters, '.', and '*'.
- It is guaranteed for each appearance of the character '*', there will be a previous valid character to match.

## Solution

**Language:** Java  
**Runtime:** 3 ms (beats 21.29%)  
**Memory:** 43.3 MB (beats 77.14%)  
**Submitted:** 2026-09-17T17:29:40.016Z  

```java
class Solution {
    public boolean isMatch(String s, String p) {
        int m = s.length();
        int n = p.length();

        boolean[][] dp = new boolean[m + 1][n + 1];

        // Empty string matches empty pattern
        dp[m][n] = true;

        // Build the table from right to left
        for (int i = m; i >= 0; i--) {
            for (int j = n - 1; j >= 0; j--) {

                boolean firstMatch = (i < m &&
                        (s.charAt(i) == p.charAt(j) || p.charAt(j) == '.'));

                // If next character is '*'
                if (j + 1 < n && p.charAt(j + 1) == '*') {

                    // Option 1: use zero occurrences
                    // Option 2: use one or more occurrences
                    dp[i][j] = dp[i][j + 2] ||
                               (firstMatch && dp[i + 1][j]);

                } else {
                    // Normal character or '.'
                    dp[i][j] = firstMatch && dp[i + 1][j + 1];
                }
            }
        }

        return dp[0][0];
    }
}
```

---

[View on LeetCode](https://leetcode.com/problems/regular-expression-matching/)