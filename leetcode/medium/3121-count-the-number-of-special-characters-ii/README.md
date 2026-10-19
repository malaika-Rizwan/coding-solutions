# Count the Number of Special Characters II

![Difficulty](https://img.shields.io/badge/Difficulty-Medium-yellow)

## Problem

You are given a string `word`. A letter `c` is called  **special**  if it appears  **both**  in lowercase and uppercase in `word`, and  **every**  lowercase occurrence of `c` appears before the  **first**  uppercase occurrence of `c`.

Return the number of  **special**  letters in `word`.

 

 **Example 1:** 

 **Input:**  word = "aaAbcBC"

 **Output:**  3

 **Explanation:** 

The special characters are `'a'`, `'b'`, and `'c'`.

 **Example 2:** 

 **Input:**  word = "abc"

 **Output:**  0

 **Explanation:** 

There are no special characters in `word`.

 **Example 3:** 

 **Input:**  word = "AbBCab"

 **Output:**  0

 **Explanation:** 

There are no special characters in `word`.

 

 **Constraints:** 

- 1 <= word.length <= 2 * 105
- word consists of only lowercase and uppercase English letters.

## Solution

**Language:** C#  
**Runtime:** 76 ms (beats 35.29%)  
**Memory:** 55.3 MB (beats 52.94%)  
**Submitted:** 2026-10-19T18:14:20.967Z  

```cs

public class Solution
{
    public int NumberOfSpecialChars(string word)
    {
        int[] lower = new int[26];
        int[] upper = new int[26];

        Array.Fill(lower, -1);
        Array.Fill(upper, -1);

        for (int i = 0; i < word.Length; i++)
        {
            char c = word[i];

            if (char.IsLower(c))
            {
                lower[c - 'a'] = i;
            }
            else
            {
                if (upper[c - 'A'] == -1)
                {
                    upper[c - 'A'] = i;
                }
            }
        }

        int count = 0;

        for (int i = 0; i < 26; i++)
        {
            if (lower[i] != -1 &&
                upper[i] != -1 &&
                lower[i] < upper[i])
            {
                count++;
            }
        }

        return count;
    }
}

```

---

[View on LeetCode](https://leetcode.com/problems/count-the-number-of-special-characters-ii/)