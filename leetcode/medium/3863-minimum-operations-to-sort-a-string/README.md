# Minimum Operations to Sort a String

![Difficulty](https://img.shields.io/badge/Difficulty-Medium-yellow)

## Problem

You are given a string `s` consisting of lowercase English letters.

In one operation, you can select any  **substring**  of `s` that is  **not**  the entire string and  **sort**  it in  **non-descending alphabetical**  order.

Return the  **minimum**  number of operations required to make `s` sorted in  **non-descending**  order. If it is not possible, return -1.

 

 **Example 1:** 

 **Input:**  s = "dog"

 **Output:**  1

 **Explanation:** ​​​​​​​

- Sort substring "og" to "go".
- Now, s = "dgo", which is sorted in ascending order. Thus, the answer is 1.

 **Example 2:** 

 **Input:**  s = "card"

 **Output:**  2

 **Explanation:** 

- Sort substring "car" to "acr", so s = "acrd".
- Sort substring "rd" to "dr", making s = "acdr", which is sorted in ascending order. Thus, the answer is 2.

 **Example 3:** 

 **Input:**  s = "gf"

 **Output:**  -1

 **Explanation:** 

- It is impossible to sort s under the given constraints. Thus, the answer is -1.

 

 **Constraints:** 

- 1 <= s.length <= 105
- s consists of only lowercase English letters.

## Solution

**Language:** C#  
**Runtime:** 0 ms  
**Memory:** 37.9 MB  
**Submitted:** 2026-10-21T13:48:30.571Z  

```cs

public class Solution
{
    public int MinOperations(string s)
    {
        int n = s.Length;

        // Already sorted
        bool sorted = true;

        for (int i = 1; i < n; i++)
        {
            if (s[i] < s[i - 1])
            {
                sorted = false;
                break;
            }
        }

        if (sorted)
            return 0;

        // A single character cannot be changed
        if (n == 1)
            return -1;

        // Length 2: the only proper substring that can
        // change the string is the whole string, which is forbidden.
        if (n == 2)
            return -1;

        // If the first character is the smallest and the last
        // character is the largest, sort the middle substring.
        char minChar = 'z';
        char maxChar = 'a';

        foreach (char c in s)
        {
            minChar = (char)Math.Min(minChar, c);
            maxChar = (char)Math.Max(maxChar, c);
        }

        if (s[0] == minChar && s[n - 1] == maxChar)
            return 1;

        // If either endpoint is already in its correct extreme
        // position, two operations are sufficient.
        if (s[0] == minChar || s[n - 1] == maxChar)
            return 2;

        // If the minimum is at the end and the maximum at the
        // beginning, three operations are sufficient.
        if (s[0] == maxChar && s[n - 1] == minChar)
            return 3;

        return 2;
    }
}

```

---

[View on LeetCode](https://leetcode.com/problems/minimum-operations-to-sort-a-string/)