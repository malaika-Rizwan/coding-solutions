
public class Solution
{
    private int[] dp;
    private int[] arr;
    private int d;

    public int MaxJumps(int[] arr, int d)
    {
        this.arr = arr;
        this.d = d;

        int n = arr.Length;
        dp = new int[n];

        int answer = 1;

        for (int i = 0; i < n; i++)
        {
            answer = Math.Max(answer, DFS(i));
        }

        return answer;
    }

    private int DFS(int i)
    {
        // Already calculated
        if (dp[i] != 0)
            return dp[i];

        // We can always visit the current index
        dp[i] = 1;

        // Jump to the left
        for (int j = i - 1; j >= Math.Max(0, i - d); j--)
        {
            if (arr[j] >= arr[i])
                break;

            dp[i] = Math.Max(dp[i], 1 + DFS(j));
        }

        // Jump to the right
        for (int j = i + 1; j <= Math.Min(arr.Length - 1, i + d); j++)
        {
            if (arr[j] >= arr[i])
                break;

            dp[i] = Math.Max(dp[i], 1 + DFS(j));
        }

        return dp[i];
    }
}
