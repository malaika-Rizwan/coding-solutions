# Maximum Path Score in a Grid

![Difficulty](https://img.shields.io/badge/Difficulty-Medium-yellow)

## Problem

You are given an `m x n` grid where each cell contains one of the values 0, 1, or 2. You are also given an integer `k`.

You start from the top-left corner `(0, 0)` and want to reach the bottom-right corner `(m - 1, n - 1)` by moving only  **right**  or  **down**.

Each cell contributes a specific score and incurs an associated cost, according to their cell values:

- 0: adds 0 to your score and costs 0.
- 1: adds 1 to your score and costs 1.
- 2: adds 2 to your score and costs 1. ​​​​​​​

Return the  **maximum**  score achievable without exceeding a total cost of `k`, or -1 if no valid path exists.

 **Note:**  If you reach the last cell but the total cost exceeds `k`, the path is invalid.

 

 **Example 1:** 

 **Input:**  grid = [[0, 1],[2, 0]], k = 1

 **Output:**  2

 **Explanation:** ​​​​​​​

The optimal path is:

Cell	grid[i][j]	Score	Total
Score	Cost	Total
Cost
(0, 0)	0	0	0	0	0
(1, 0)	2	2	2	1	1
(1, 1)	0	0	2	0	1

Thus, the maximum possible score is 2.

 **Example 2:** 

 **Input:**  grid = [[0, 1],[1, 2]], k = 1

 **Output:**  -1

 **Explanation:** 

There is no path that reaches cell `(1, 1)`​​​​​​​ without exceeding cost k. Thus, the answer is -1.

 

 **Constraints:** 

- 1 <= m, n <= 200
- 0 <= k <= 103​​​​​​​
- ​​​​​​​grid[0][0] == 0
- 0 <= grid[i][j] <= 2

## Solution

**Language:** C#  
**Runtime:** 327 ms (beats 75.00%)  
**Memory:** 68.6 MB (beats 25.00%)  
**Submitted:** 2026-09-26T16:39:59.932Z  

```cs
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
```

---

[View on LeetCode](https://leetcode.com/problems/maximum-path-score-in-a-grid/)