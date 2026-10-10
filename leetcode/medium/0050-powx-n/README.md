# Pow(x, n)

![Difficulty](https://img.shields.io/badge/Difficulty-Medium-yellow)

## Problem

Implement pow(x, n), which calculates `x` raised to the power `n` (i.e., `xn`).

 

 **Example 1:** 

```
Input: x = 2.00000, n = 10
Output: 1024.00000

```

 **Example 2:** 

```
Input: x = 2.10000, n = 3
Output: 9.26100

```

 **Example 3:** 

```
Input: x = 2.00000, n = -2
Output: 0.25000
Explanation: 2-2 = 1/22 = 1/4 = 0.25

```

 

 **Constraints:** 

- -100.0 < x < 100.0
- -231 <= n <= 231-1
- n is an integer.
- Either x is not zero or n > 0.
- -104 <= xn <= 104

## Solution

**Language:** C#  
**Runtime:** 0 ms (beats 100.00%)  
**Memory:** 29.5 MB (beats 15.76%)  
**Submitted:** 2026-10-10T18:43:12.556Z  

```cs

public class Solution
{
    public double MyPow(double x, int n)
    {
        long power = n;
        bool negative = power < 0;

        power = Math.Abs(power);

        double result = 1.0;

        while (power > 0)
        {
            if ((power & 1) == 1)
            {
                result *= x;
            }

            x *= x;
            power >>= 1;
        }

        return negative ? 1.0 / result : result;
    }
}

```

---

[View on LeetCode](https://leetcode.com/problems/powx-n/)