
public class Solution
{
    public int MinSwaps(int[] nums)
    {
        int n = nums.Length;

        int DigitSum(int num)
        {
            int sum = 0;

            while (num > 0)
            {
                sum += num % 10;
                num /= 10;
            }

            return sum;
        }

        int[][] arr = new int[n][];

        for (int i = 0; i < n; i++)
        {
            arr[i] = new int[] { nums[i], i };
        }

        Array.Sort(arr, (a, b) =>
        {
            int sumA = DigitSum(a[0]);
            int sumB = DigitSum(b[0]);

            if (sumA != sumB)
                return sumA.CompareTo(sumB);

            return a[0].CompareTo(b[0]);
        });

        bool[] visited = new bool[n];
        int swaps = 0;

        for (int i = 0; i < n; i++)
        {
            if (visited[i] || arr[i][1] == i)
                continue;

            int cycleSize = 0;
            int j = i;

            while (!visited[j])
            {
                visited[j] = true;
                j = arr[j][1];
                cycleSize++;
            }

            swaps += cycleSize - 1;
        }

        return swaps;
    }
}
