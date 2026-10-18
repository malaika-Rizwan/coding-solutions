
using System;
using System.Collections.Generic;

public class Solution
{
    private const long MOD = 1_000_000_007;
    private long[,] comb;

    public int NumOfWays(int[] nums)
    {
        int n = nums.Length;

        // Precompute combinations: C(n, k)
        comb = new long[n + 1, n + 1];

        for (int i = 0; i <= n; i++)
        {
            comb[i, 0] = 1;
            comb[i, i] = 1;

            for (int j = 1; j < i; j++)
            {
                comb[i, j] =
                    (comb[i - 1, j - 1] + comb[i - 1, j]) % MOD;
            }
        }

        List<int> list = new List<int>(nums);

        // Subtract the original ordering
        return (int)((CountWays(list) - 1 + MOD) % MOD);
    }

    private long CountWays(List<int> nums)
    {
        int n = nums.Count;

        if (n <= 2)
            return 1;

        int root = nums[0];

        List<int> left = new List<int>();
        List<int> right = new List<int>();

        for (int i = 1; i < n; i++)
        {
            if (nums[i] < root)
                left.Add(nums[i]);
            else
                right.Add(nums[i]);
        }

        long leftWays = CountWays(left);
        long rightWays = CountWays(right);

        long interleavings = comb[n - 1, left.Count];

        return (((interleavings * leftWays) % MOD)
                * rightWays) % MOD;
    }
}
