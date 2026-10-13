
using System;

public class Solution
{
    public long MaxAlternatingSum(int[] nums)
    {
        long[] squares = new long[nums.Length];

        for (int i = 0; i < nums.Length; i++)
        {
            squares[i] = (long)nums[i] * nums[i];
        }

        Array.Sort(squares);

        long score = 0;
        int n = squares.Length;
        int negativeCount = n / 2;

        for (int i = 0; i < n; i++)
        {
            if (i < negativeCount)
                score -= squares[i];
            else
                score += squares[i];
        }

        return score;
    }
}
