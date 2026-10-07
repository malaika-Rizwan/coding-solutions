# Separate the Digits in an Array

![Difficulty](https://img.shields.io/badge/Difficulty-Easy-green)

## Problem

Given an array of positive integers `nums`, return  *an array* `answer` *that consists of the digits of each integer in* `nums` *after separating them in  **the same order**  they appear in* `nums`.

To separate the digits of an integer is to get all the digits it has in the same order.

- For example, for the integer 10921, the separation of its digits is [1,0,9,2,1].

 

 **Example 1:** 

```
Input: nums = [13,25,83,77]
Output: [1,3,2,5,8,3,7,7]
Explanation: 
- The separation of 13 is [1,3].
- The separation of 25 is [2,5].
- The separation of 83 is [8,3].
- The separation of 77 is [7,7].
answer = [1,3,2,5,8,3,7,7]. Note that answer contains the separations in the same order.

```

 **Example 2:** 

```
Input: nums = [7,1,3,9]
Output: [7,1,3,9]
Explanation: The separation of each integer in nums is itself.
answer = [7,1,3,9].

```

 

 **Constraints:** 

- 1 <= nums.length <= 1000
- 1 <= nums[i] <= 105

## Solution

**Language:** C#  
**Runtime:** 6 ms (beats 47.25%)  
**Memory:** 51.2 MB (beats 49.45%)  
**Submitted:** 2026-10-07T17:36:40.764Z  

```cs
public class Solution
{
    public int[] SeparateDigits(int[] nums)
    {
        List<int> answer = new List<int>();

        foreach (int number in nums)
        {
            int num = number;
            List<int> digits = new List<int>();

            while (num > 0)
            {
                int digit = num % 10;
                digits.Add(digit);
                num = num / 10;
            }

            digits.Reverse();

            answer.AddRange(digits);
        }

        return answer.ToArray();
    }
}
```

---

[View on LeetCode](https://leetcode.com/problems/separate-the-digits-in-an-array/)