# Valid Sudoku

![Difficulty](https://img.shields.io/badge/Difficulty-Medium-yellow)

## Problem

Determine if a `9 x 9` Sudoku board is valid. Only the filled cells need to be validated  **according to the following rules** :

- Each row must contain the digits 1-9 without repetition.
- Each column must contain the digits 1-9 without repetition.
- Each of the nine 3 x 3 sub-boxes of the grid must contain the digits 1-9 without repetition.

 **Note:** 

- A Sudoku board (partially filled) could be valid but is not necessarily solvable.
- Only the filled cells need to be validated according to the mentioned rules.

 

 **Example 1:** 

```
Input: board = 
[["5","3",".",".","7",".",".",".","."]
,["6",".",".","1","9","5",".",".","."]
,[".","9","8",".",".",".",".","6","."]
,["8",".",".",".","6",".",".",".","3"]
,["4",".",".","8",".","3",".",".","1"]
,["7",".",".",".","2",".",".",".","6"]
,[".","6",".",".",".",".","2","8","."]
,[".",".",".","4","1","9",".",".","5"]
,[".",".",".",".","8",".",".","7","9"]]
Output: true

```

 **Example 2:** 

```
Input: board = 
[["8","3",".",".","7",".",".",".","."]
,["6",".",".","1","9","5",".",".","."]
,[".","9","8",".",".",".",".","6","."]
,["8",".",".",".","6",".",".",".","3"]
,["4",".",".","8",".","3",".",".","1"]
,["7",".",".",".","2",".",".",".","6"]
,[".","6",".",".",".",".","2","8","."]
,[".",".",".","4","1","9",".",".","5"]
,[".",".",".",".","8",".",".","7","9"]]
Output: false
Explanation: Same as Example 1, except with the 5 in the top left corner being modified to 8. Since there are two 8's in the top left 3x3 sub-box, it is invalid.

```

 

 **Constraints:** 

- board.length == 9
- board[i].length == 9
- board[i][j] is a digit 1-9 or '.'.

## Solution

**Language:** C#  
**Runtime:** 2 ms (beats 77.22%)  
**Memory:** 49.4 MB (beats 41.06%)  
**Submitted:** 2026-09-25T16:34:32.922Z  

```cs
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
```

---

[View on LeetCode](https://leetcode.com/problems/valid-sudoku/)