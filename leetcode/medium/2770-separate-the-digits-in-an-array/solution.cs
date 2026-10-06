public class Solution
{
    public int MaximumJumps(int[] nums, int target)
    {
        int n = nums.Length;

        int[] dp = new int[n];

        // -1 means this index is not reachable
        Array.Fill(dp, -1);

        // We start at index 0
        dp[0] = 0;

        for (int i = 0; i < n; i++)
        {
            // If we cannot reach i, skip it
            if (dp[i] == -1)
                continue;

            for (int j = i + 1; j < n; j++)
            {
                if (Math.Abs(nums[j] - nums[i]) <= target)
                {
                    dp[j] = Math.Max(dp[j], dp[i] + 1);
                }
            }
        }

        return dp[n - 1];
    }
}