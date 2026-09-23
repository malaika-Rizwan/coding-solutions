# Substring with Concatenation of All Words

![Difficulty](https://img.shields.io/badge/Difficulty-Hard-red)

## Problem

You are given a string `s` and an array of strings `words`. All the strings of `words` are of  **the same length**.

A  **concatenated string**  is a string that exactly contains all the strings of any permutation of `words` concatenated.

- For example, if words = ["ab","cd","ef"], then "abcdef", "abefcd", "cdabef", "cdefab", "efabcd", and "efcdab" are all concatenated strings. "acdbef" is not a concatenated string because it is not the concatenation of any permutation of words.

Return an array of  *the starting indices*  of all the concatenated substrings in `s`. You can return the answer in  **any order**.

 

 **Example 1:** 

 **Input:**  s = "barfoothefoobarman", words = ["foo","bar"]

 **Output:**  [0,9]

 **Explanation:** 

The substring starting at 0 is `"barfoo"`. It is the concatenation of `["bar","foo"]` which is a permutation of `words`.
The substring starting at 9 is `"foobar"`. It is the concatenation of `["foo","bar"]` which is a permutation of `words`.

 **Example 2:** 

 **Input:**  s = "wordgoodgoodgoodbestword", words = ["word","good","best","word"]

 **Output:**  []

 **Explanation:** 

There is no concatenated substring.

 **Example 3:** 

 **Input:**  s = "barfoofoobarthefoobarman", words = ["bar","foo","the"]

 **Output:**  [6,9,12]

 **Explanation:** 

The substring starting at 6 is `"foobarthe"`. It is the concatenation of `["foo","bar","the"]`.
The substring starting at 9 is `"barthefoo"`. It is the concatenation of `["bar","the","foo"]`.
The substring starting at 12 is `"thefoobar"`. It is the concatenation of `["the","foo","bar"]`.

 

 **Constraints:** 

- 1 <= s.length <= 104
- 1 <= words.length <= 5000
- 1 <= words[i].length <= 30
- s and words[i] consist of lowercase English letters.

## Solution

**Language:** Java  
**Runtime:** 11 ms (beats 94.17%)  
**Memory:** 47.2 MB (beats 76.72%)  
**Submitted:** 2026-09-23T17:16:25.116Z  

```java
import java.util.*;

class Solution {
    public List<Integer> findSubstring(String s, String[] words) {

        List<Integer> result = new ArrayList<>();

        if (s == null || words == null || words.length == 0) {
            return result;
        }

        int wordLen = words[0].length();
        int wordCount = words.length;
        int totalLen = wordLen * wordCount;

        if (s.length() < totalLen) {
            return result;
        }

        // Frequency of words we need
        Map<String, Integer> target = new HashMap<>();

        for (String word : words) {
            target.put(word, target.getOrDefault(word, 0) + 1);
        }

        // Try every possible offset
        for (int offset = 0; offset < wordLen; offset++) {

            int left = offset;
            int right = offset;
            int count = 0;

            Map<String, Integer> window = new HashMap<>();

            while (right + wordLen <= s.length()) {

                // Take the next word
                String word = s.substring(right, right + wordLen);
                right += wordLen;

                // Word is not required
                if (!target.containsKey(word)) {
                    window.clear();
                    count = 0;
                    left = right;
                    continue;
                }

                // Add word to current window
                window.put(word, window.getOrDefault(word, 0) + 1);
                count++;

                // Too many copies of this word
                while (window.get(word) > target.get(word)) {

                    String leftWord = s.substring(left, left + wordLen);

                    window.put(
                        leftWord,
                        window.get(leftWord) - 1
                    );

                    left += wordLen;
                    count--;
                }

                // We found all words
                if (count == wordCount) {
                    result.add(left);

                    // Move window forward for next possible answer
                    String leftWord = s.substring(left, left + wordLen);

                    window.put(
                        leftWord,
                        window.get(leftWord) - 1
                    );

                    left += wordLen;
                    count--;
                }
            }
        }

        return result;
    }
}
```

---

[View on LeetCode](https://leetcode.com/problems/substring-with-concatenation-of-all-words/)