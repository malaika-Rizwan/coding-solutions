# Count the Number of Special Characters I

![Difficulty](https://img.shields.io/badge/Difficulty-Easy-green)

## Problem

You are given a string `word`. A letter is called  **special**  if it appears  **both**  in lowercase and uppercase in `word`.

Return the number of  **special**  letters in `word`.

 

 **Example 1:** 

 **Input:**  word = "aaAbcBC"

 **Output:**  3

 **Explanation:** 

The special characters in `word` are `'a'`, `'b'`, and `'c'`.

 **Example 2:** 

 **Input:**  word = "abc"

 **Output:**  0

 **Explanation:** 

No character in `word` appears in uppercase.

 **Example 3:** 

 **Input:**  word = "abBCab"

 **Output:**  1

 **Explanation:** 

The only special character in `word` is `'b'`.

 

 **Constraints:** 

- 1 <= word.length <= 50
- word consists of only lowercase and uppercase English letters.

## Solution

**Language:** C#  
**Runtime:** 0 ms (beats 100.00%)  
**Memory:** 40 MB (beats 94.74%)  
**Submitted:** 2026-10-19T18:12:24.274Z  

```cs

public class Solution
{
    public int NumberOfSpecialChars(string word)
    {
        bool[] lower = new bool[26];
        bool[] upper = new bool[26];

        foreach (char c in word)
        {
            if (char.IsLower(c))
            {
                lower[c - 'a'] = true;
            }
            else
            {
                upper[c - 'A'] = true;
            }
        }

        int count = 0;

        for (int i = 0; i < 26; i++)
        {
            if (lower[i] && upper[i])
            {
                count++;
            }
        }

        return count;
    }
}

```

---

[View on LeetCode](https://leetcode.com/problems/count-the-number-of-special-characters-i/)