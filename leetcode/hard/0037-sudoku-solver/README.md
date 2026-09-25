# Sudoku Solver

![Difficulty](https://img.shields.io/badge/Difficulty-Hard-red)

## Problem

Write a program to solve a Sudoku puzzle by filling the empty cells.

A sudoku solution must satisfy  **all of the following rules** :

- Each of the digits 1-9 must occur exactly once in each row.
- Each of the digits 1-9 must occur exactly once in each column.
- Each of the digits 1-9 must occur exactly once in each of the 9 3x3 sub-boxes of the grid.

The `'.'` character indicates empty cells.

 

 **Example 1:** 

```
Input: board = [["5","3",".",".","7",".",".",".","."],["6",".",".","1","9","5",".",".","."],[".","9","8",".",".",".",".","6","."],["8",".",".",".","6",".",".",".","3"],["4",".",".","8",".","3",".",".","1"],["7",".",".",".","2",".",".",".","6"],[".","6",".",".",".",".","2","8","."],[".",".",".","4","1","9",".",".","5"],[".",".",".",".","8",".",".","7","9"]]
Output: [["5","3","4","6","7","8","9","1","2"],["6","7","2","1","9","5","3","4","8"],["1","9","8","3","4","2","5","6","7"],["8","5","9","7","6","1","4","2","3"],["4","2","6","8","5","3","7","9","1"],["7","1","3","9","2","4","8","5","6"],["9","6","1","5","3","7","2","8","4"],["2","8","7","4","1","9","6","3","5"],["3","4","5","2","8","6","1","7","9"]]
Explanation: The input board is shown above and the only valid solution is shown below:

```

 

 **Constraints:** 

- board.length == 9
- board[i].length == 9
- board[i][j] is a digit or '.'.
- It is guaranteed that the input board has only one solution.

## Solution

**Language:** C#  
**Runtime:** 1677 ms (beats 5.04%)  
**Memory:** 47.9 MB (beats 76.73%)  
**Submitted:** 2026-09-25T16:40:32.523Z  

```cs
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
```

---

[View on LeetCode](https://leetcode.com/problems/sudoku-solver/)