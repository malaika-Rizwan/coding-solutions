# N-Queens

![Difficulty](https://img.shields.io/badge/Difficulty-Hard-red)

## Problem

The  **n-queens**  puzzle is the problem of placing `n` queens on an `n x n` chessboard such that no two queens attack each other.

Given an integer `n`, return  *all distinct solutions to the  **n-queens puzzle***. You may return the answer in  **any order**.

Each solution contains a distinct board configuration of the n-queens' placement, where `'Q'` and `'.'` both indicate a queen and an empty space, respectively.

 

 **Example 1:** 

```
Input: n = 4
Output: [[".Q..","...Q","Q...","..Q."],["..Q.","Q...","...Q",".Q.."]]
Explanation: There exist two distinct solutions to the 4-queens puzzle as shown above

```

 **Example 2:** 

```
Input: n = 1
Output: [["Q"]]

```

 

 **Constraints:** 

- 1 <= n <= 9

## Solution

**Language:** C#  
**Runtime:** 9 ms (beats 63.97%)  
**Memory:** 52.9 MB (beats 97.57%)  
**Submitted:** 2026-10-10T18:44:21.062Z  

```cs

public class Solution
{
    public IList<IList<string>> SolveNQueens(int n)
    {
        var result = new List<IList<string>>();
        char[][] board = new char[n][];

        for (int i = 0; i < n; i++)
        {
            board[i] = new string('.', n).ToCharArray();
        }

        Backtrack(0);

        return result;

        void Backtrack(int row)
        {
            if (row == n)
            {
                var solution = new List<string>();

                foreach (char[] line in board)
                {
                    solution.Add(new string(line));
                }

                result.Add(solution);
                return;
            }

            for (int col = 0; col < n; col++)
            {
                if (!IsSafe(row, col))
                    continue;

                board[row][col] = 'Q';

                Backtrack(row + 1);

                board[row][col] = '.';
            }
        }

        bool IsSafe(int row, int col)
        {
            for (int r = 0; r < row; r++)
            {
                if (board[r][col] == 'Q')
                    return false;

                int left = col - (row - r);
                if (left >= 0 && board[r][left] == 'Q')
                    return false;

                int right = col + (row - r);
                if (right < n && board[r][right] == 'Q')
                    return false;
            }

            return true;
        }
    }
}

```

---

[View on LeetCode](https://leetcode.com/problems/n-queens/)