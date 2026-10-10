
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
