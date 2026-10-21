
public class Solution
{
    public int SortableIntegers(int[] nums)
    {
        int n = nums.Length;
        int answer = 0;

        // Check all divisors of n
        for (int k = 1; k <= n; k++)
        {
            if (n % k == 0 && IsSortable(nums, k))
            {
                answer += k;
            }
        }

        return answer;
    }

    private bool IsSortable(int[] nums, int k)
    {
        int n = nums.Length;
        int previousMax = int.MinValue;

        // Divide array into blocks of size k
        for (int start = 0; start < n; start += k)
        {
            int end = start + k - 1;
            int min = nums[start];
            int max = nums[start];
            int descents = 0;

            // Count descending pairs, including circular wraparound
            for (int i = start; i <= end; i++)
            {
                int next = (i == end) ? start : i + 1;

                if (nums[i] > nums[next])
                {
                    descents++;
                }

                min = Math.Min(min, nums[i]);
                max = Math.Max(max, nums[i]);
            }

            // More than one circular descent means invalid
            if (descents > 1)
            {
                return false;
            }

            // Blocks must also be in the correct global order
            if (previousMax > min)
            {
                return false;
            }

            previousMax = max;
        }

        return true;
    }
}
