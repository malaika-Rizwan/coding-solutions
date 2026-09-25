public class Solution
{
    public void SolveSudoku(char[][] board)
    {
        Solve(board);
    }

    private bool Solve(char[][] board)
    {
        // Find an empty cell
        for (int row = 0; row < 9; row++)
        {
            for (int col = 0; col < 9; col++)
            {
                if (board[row][col] == '.')
                {
                    // Try digits 1 to 9
                    for (char num = '1'; num <= '9'; num++)
                    {
                        if (IsValid(board, row, col, num))
                        {
                            // Place number
                            board[row][col] = num;

                            // Recursively solve
                            if (Solve(board))
                            {
                                return true;
                            }

                            // Backtrack
                            board[row][col] = '.';
                        }
                    }

                    // No number works
                    return false;
                }
            }
        }

        // No empty cells → Sudoku solved
        return true;
    }

    private bool IsValid(char[][] board, int row, int col, char num)
    {
        // Check row
        for (int c = 0; c < 9; c++)
        {
            if (board[row][c] == num)
                return false;
        }

        // Check column
        for (int r = 0; r < 9; r++)
        {
            if (board[r][col] == num)
                return false;
        }

        // Find 3x3 box starting position
        int startRow = (row / 3) * 3;
        int startCol = (col / 3) * 3;

        // Check 3x3 box
        for (int r = startRow; r < startRow + 3; r++)
        {
            for (int c = startCol; c < startCol + 3; c++)
            {
                if (board[r][c] == num)
                    return false;
            }
        }

        return true;
    }
}