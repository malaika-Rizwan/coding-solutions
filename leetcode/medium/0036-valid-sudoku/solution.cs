public class Solution
{
    public bool IsValidSudoku(char[][] board)
    {
        // Check rows
        for (int row = 0; row < 9; row++)
        {
            HashSet<char> seen = new HashSet<char>();

            for (int col = 0; col < 9; col++)
            {
                char value = board[row][col];

                if (value == '.')
                    continue;

                if (seen.Contains(value))
                    return false;

                seen.Add(value);
            }
        }

        // Check columns
        for (int col = 0; col < 9; col++)
        {
            HashSet<char> seen = new HashSet<char>();

            for (int row = 0; row < 9; row++)
            {
                char value = board[row][col];

                if (value == '.')
                    continue;

                if (seen.Contains(value))
                    return false;

                seen.Add(value);
            }
        }

        // Check 3 x 3 boxes
        for (int boxRow = 0; boxRow < 9; boxRow += 3)
        {
            for (int boxCol = 0; boxCol < 9; boxCol += 3)
            {
                HashSet<char> seen = new HashSet<char>();

                for (int row = boxRow; row < boxRow + 3; row++)
                {
                    for (int col = boxCol; col < boxCol + 3; col++)
                    {
                        char value = board[row][col];

                        if (value == '.')
                            continue;

                        if (seen.Contains(value))
                            return false;

                        seen.Add(value);
                    }
                }
            }
        }

        return true;
    }
}