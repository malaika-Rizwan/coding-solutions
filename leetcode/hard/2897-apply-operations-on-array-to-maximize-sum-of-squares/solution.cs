
public class Solution
{
    public int MaxSum(IList<int> nums, int k)
    {
        const long MOD = 1_000_000_007;
        int[] bits = new int[32];

        // Count how many numbers contain each set bit
        foreach (int num in nums)
        {
            for (int b = 0; b < 32; b++)
            {
                if ((num & (1 << b)) != 0)
                {
                    bits[b]++;
                }
            }
        }

        long result = 0;

        // Construct the largest possible number k times
        for (int i = 0; i < k; i++)
        {
            long x = 0;

            for (int b = 0; b < 32; b++)
            {
                if (bits[b] > 0)
                {
                    x |= (1L << b);
                    bits[b]--;
                }
            }

            result = (result + x * x) % MOD;
        }

        return (int)result;
    }
}
