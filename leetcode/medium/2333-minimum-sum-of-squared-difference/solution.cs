public class Solution
{
    public long MinSumSquareDiff(int[] nums1, int[] nums2, int k1, int k2)
    {
        long operations = (long)k1 + k2;
        int[] freq = new int[100001];
        int maxDiff = 0;

        for (int i = 0; i < nums1.Length; i++)
        {
            int diff = Math.Abs(nums1[i] - nums2[i]);
            freq[diff]++;
            maxDiff = Math.Max(maxDiff, diff);
        }

        for (int d = maxDiff; d > 0 && operations > 0; d--)
        {
            long count = freq[d];
            long use = Math.Min(count, operations);

            freq[d] -= (int)use;
            freq[d - 1] += (int)use;
            operations -= use;
        }

        long answer = 0;

        for (int d = 1; d < freq.Length; d++)
        {
            answer += (long)d * d * freq[d];
        }

        return answer;
    }
}