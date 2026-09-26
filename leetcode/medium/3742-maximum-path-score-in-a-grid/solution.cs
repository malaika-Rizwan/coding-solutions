public class Solution
{
    public int MaxPathScore(int[][] grid, int k)
    {
        int m = grid.Length;
        int n = grid[0].Length;

        // dp[i][j][cost] = maximum score
        // -1 means this state is impossible
        int[][][] dp = new int[m][][];

        for (int i = 0; i < m; i++)
        {
            dp[i] = new int[n][];

            for (int j = 0; j < n; j++)
            {
                dp[i][j] = new int[k + 1];

                for (int c = 0; c <= k; c++)
                {
                    dp[i][j][c] = -1;
                }
            }
        }

        // Starting point
        dp[0][0][0] = 0;

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i == 0 && j == 0)
                    continue;

                int value = grid[i][j];

                int cost = (value == 0) ? 0 : 1;
                int score = value;

                for (int currentCost = cost;
                     currentCost <= k;
                     currentCost++)
                {
                    int previousCost = currentCost - cost;

                    // Come from above
                    if (i > 0 &&
                        dp[i - 1][j][previousCost] != -1)
                    {
                        dp[i][j][currentCost] = Math.Max(
                            dp[i][j][currentCost],
                            dp[i - 1][j][previousCost] + score
                        );
                    }

                    // Come from left
                    if (j > 0 &&
                        dp[i][j - 1][previousCost] != -1)
                    {
                        dp[i][j][currentCost] = Math.Max(
                            dp[i][j][currentCost],
                            dp[i][j - 1][previousCost] + score
                        );
                    }
                }
            }
        }

        int answer = -1;

        // We can use any cost <= k
        for (int cost = 0; cost <= k; cost++)
        {
            answer = Math.Max(
                answer,
                dp[m - 1][n - 1][cost]
            );
        }

        return answer;
    }
}