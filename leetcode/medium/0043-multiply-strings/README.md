# Multiply Strings

![Difficulty](https://img.shields.io/badge/Difficulty-Medium-yellow)

## Problem

Given two non-negative integers `num1` and `num2` represented as strings, return the product of `num1` and `num2`, also represented as a string.

 **Note:**  You must not use any built-in BigInteger library or convert the inputs to integer directly.

 

 **Example 1:** 

```
Input: num1 = "2", num2 = "3"
Output: "6"

```

 **Example 2:** 

```
Input: num1 = "123", num2 = "456"
Output: "56088"

```

 

 **Constraints:** 

- 1 <= num1.length, num2.length <= 200
- num1 and num2 consist of digits only.
- Both num1 and num2 do not contain any leading zero, except the number 0 itself.

## Solution

**Language:** Java  
**Runtime:** 3 ms (beats 77.71%)  
**Memory:** 43.8 MB (beats 29.02%)  
**Submitted:** 2026-09-28T17:37:16.425Z  

```java
class Solution {
    public String multiply(String num1, String num2) {

        // If either number is zero
        if (num1.equals("0") || num2.equals("0")) {
            return "0";
        }

        int m = num1.length();
        int n = num2.length();

        int[] result = new int[m + n];

        // Multiply every digit
        for (int i = m - 1; i >= 0; i--) {

            for (int j = n - 1; j >= 0; j--) {

                int digit1 = num1.charAt(i) - '0';
                int digit2 = num2.charAt(j) - '0';

                int product = digit1 * digit2;

                int position1 = i + j;
                int position2 = i + j + 1;

                int sum = product + result[position2];

                result[position2] = sum % 10;
                result[position1] += sum / 10;
            }
        }

        // Convert array to String
        StringBuilder answer = new StringBuilder();

        for (int digit : result) {

            // Skip leading zeros
            if (answer.length() == 0 && digit == 0) {
                continue;
            }

            answer.append(digit);
        }

        return answer.toString();
    }
}
```

---

[View on LeetCode](https://leetcode.com/problems/multiply-strings/)