# Intersection of Two Arrays

![Difficulty](https://img.shields.io/badge/Difficulty-Easy-green)

## Problem

Given two integer arrays `nums1` and `nums2`, return  *an array of their intersection*. Each element in the result must be  **unique**  and you may return the result in  **any order**.

 

 **Example 1:** 

```
Input: nums1 = [1,2,2,1], nums2 = [2,2]
Output: [2]

```

 **Example 2:** 

```
Input: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
Output: [9,4]
Explanation: [4,9] is also accepted.

```

 

 **Constraints:** 

- 1 <= nums1.length, nums2.length <= 1000
- 0 <= nums1[i], nums2[i] <= 1000

## Solution

**Language:** C#  
**Runtime:** 4 ms (beats 60.91%)  
**Memory:** 47.6 MB (beats 35.27%)  
**Submitted:** 2026-09-25T16:24:52.270Z  

```cs
public class Solution
{
    public int[] Intersection(int[] nums1, int[] nums2)
    {
        HashSet<int> set1 = new HashSet<int>(nums1);
        HashSet<int> result = new HashSet<int>();

        foreach (int num in nums2)
        {
            if (set1.Contains(num))
            {
                result.Add(num);
            }
        }

        return result.ToArray();
    }
}
```

---

[View on LeetCode](https://leetcode.com/problems/intersection-of-two-arrays/)