# Jump Game VII

![Difficulty](https://img.shields.io/badge/Difficulty-Medium-yellow)

## Problem

You are given a  **0-indexed**  binary string `s` and two integers `minJump` and `maxJump`. In the beginning, you are standing at index `0`, which is equal to `'0'`. You can move from index `i` to index `j` if the following conditions are fulfilled:

- i + minJump <= j <= min(i + maxJump, s.length - 1), and
- s[j] == '0'.

Return `true` *if you can reach index* `s.length - 1` *in* `s` *, or* `false` *otherwise.* 

 

 **Example 1:** 

```
Input: s = "011010", minJump = 2, maxJump = 3
Output: true
Explanation:
In the first step, move from index 0 to index 3. 
In the second step, move from index 3 to index 5.

```

 **Example 2:** 

```
Input: s = "01101110", minJump = 2, maxJump = 3
Output: false

```

 

 **Constraints:** 

- 2 <= s.length <= 105
- s[i] is either '0' or '1'.
- s[0] == '0'
- 1 <= minJump <= maxJump < s.length

## Solution

**Language:** C#  
**Runtime:** 7 ms (beats 23.08%)  
**Memory:** 49 MB (beats 100.00%)  
**Submitted:** 2026-10-19T18:09:22.825Z  

```cs

public class Solution
{
    public bool CanReach(string s, int minJump, int maxJump)
    {
        int n = s.Length;

        bool[] dp = new bool[n];
        dp[0] = true;

        int reachable = 0;

        for (int i = 1; i < n; i++)
        {
            // Add the index that has just entered
            // the valid jumping range
            int add = i - minJump;

            if (add >= 0 && dp[add])
            {
                reachable++;
            }

            // Remove the index that has left
            // the valid jumping range
            int remove = i - maxJump - 1;

            if (remove >= 0 && dp[remove])
            {
                reachable--;
            }

            // We can reach i if a previous valid
            // index can jump to it and s[i] is '0'
            dp[i] = s[i] == '0' && reachable > 0;
        }

        return dp[n - 1];
    }
}

```

---

[View on LeetCode](https://leetcode.com/problems/jump-game-vii/)