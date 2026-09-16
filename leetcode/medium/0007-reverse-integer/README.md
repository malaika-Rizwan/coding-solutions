# Reverse Integer

![Difficulty](https://img.shields.io/badge/Difficulty-Medium-yellow)

## Problem

Given a signed 32-bit integer `x`, return `x` *with its digits reversed*. If reversing `x` causes the value to go outside the signed 32-bit integer range `[-231, 231 - 1]`, then return `0`.

 **Assume the environment does not allow you to store 64-bit integers (signed or unsigned).** 

 

 **Example 1:** 

```
Input: x = 123
Output: 321

```

 **Example 2:** 

```
Input: x = -123
Output: -321

```

 **Example 3:** 

```
Input: x = 120
Output: 21

```

 

 **Constraints:** 

- -231 <= x <= 231 - 1

## Solution

**Language:** Java  
**Runtime:** 1 ms (beats 99.96%)  
**Memory:** 42.7 MB (beats 26.71%)  
**Submitted:** 2026-09-16T14:46:50.188Z  

```java
class Solution {
    public int reverse(int x) {

        int result = 0;

        while (x != 0) {

            // Get the last digit
            int digit = x % 10;

            // Check for overflow before multiplying
            if (result > Integer.MAX_VALUE / 10 ||
                (result == Integer.MAX_VALUE / 10 && digit > 7)) {
                return 0;
            }

            if (result < Integer.MIN_VALUE / 10 ||
                (result == Integer.MIN_VALUE / 10 && digit < -8)) {
                return 0;
            }

            // Add digit to result
            result = result * 10 + digit;

            // Remove last digit from x
            x = x / 10;
        }

        return result;
    }
}
```

---

[View on LeetCode](https://leetcode.com/problems/reverse-integer/)