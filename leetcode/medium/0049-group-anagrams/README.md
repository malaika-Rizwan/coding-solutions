# Group Anagrams

![Difficulty](https://img.shields.io/badge/Difficulty-Medium-yellow)

## Problem

Given an array of strings `strs`, group the anagrams together. You can return the answer in  **any order**.

 

 **Example 1:** 

 **Input:**  strs = ["eat","tea","tan","ate","nat","bat"]

 **Output:**  [["bat"],["nat","tan"],["ate","eat","tea"]]

 **Explanation:** 

- There is no string in strs that can be rearranged to form "bat".
- The strings "nat" and "tan" are anagrams as they can be rearranged to form each other.
- The strings "ate", "eat", and "tea" are anagrams as they can be rearranged to form each other.

 **Example 2:** 

 **Input:**  strs = [""]

 **Output:**  [[""]]

 **Example 3:** 

 **Input:**  strs = ["a"]

 **Output:**  [["a"]]

 

 **Constraints:** 

- 1 <= strs.length <= 104
- 0 <= strs[i].length <= 100
- strs[i] consists of lowercase English letters.

## Solution

**Language:** C#  
**Runtime:** 23 ms (beats 51.80%)  
**Memory:** 66.8 MB (beats 77.52%)  
**Submitted:** 2026-10-06T15:29:54.766Z  

```cs
public class Solution
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();

        foreach (string str in strs)
        {
            // Convert string to character array
            char[] chars = str.ToCharArray();

            // Sort the characters
            Array.Sort(chars);

            // Convert back to string
            string key = new string(chars);

            // If this key doesn't exist, create a new list
            if (!map.ContainsKey(key))
            {
                map[key] = new List<string>();
            }

            // Add the original string to its group
            map[key].Add(str);
        }

        return new List<IList<string>>(map.Values);
    }
}
```

---

[View on LeetCode](https://leetcode.com/problems/group-anagrams/)