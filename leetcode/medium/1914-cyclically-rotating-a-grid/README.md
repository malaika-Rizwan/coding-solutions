# Cyclically Rotating a Grid

![Difficulty](https://img.shields.io/badge/Difficulty-Medium-yellow)

## Problem

You are given an `m x n` integer matrix `grid`​​​, where `m` and `n` are both  **even**  integers, and an integer `k`.

The matrix is composed of several layers, which is shown in the below image, where each color is its own layer:

A cyclic rotation of the matrix is done by cyclically rotating  **each layer**  in the matrix. To cyclically rotate a layer once, each element in the layer will take the place of the adjacent element in the  **counter-clockwise**  direction. An example rotation is shown below:

Return  *the matrix after applying* `k`  *cyclic rotations to it*.

 

 **Example 1:** 

```
Input: grid = [[40,10],[30,20]], k = 1
Output: [[10,20],[40,30]]
Explanation: The figures above represent the grid at every state.

```

 **Example 2:** 

```
Input: grid = [[1,2,3,4],[5,6,7,8],[9,10,11,12],[13,14,15,16]], k = 2
Output: [[3,4,8,12],[2,11,10,16],[1,7,6,15],[5,9,13,14]]
Explanation: The figures above represent the grid at every state.

```

 

 **Constraints:** 

- m == grid.length
- n == grid[i].length
- 2 <= m, n <= 50
- Both m and n are even integers.
- 1 <= grid[i][j] <= 5000
- 1 <= k <= 109

## Solution

**Language:** C#  
**Runtime:** 166 ms (beats 44.44%)  
**Memory:** 58.6 MB (beats 44.44%)  
**Submitted:** 2026-10-05T14:39:20.750Z  

```cs
public class Solution
{
    public int[][] RotateGrid(int[][] grid, int k)
    {
        int m = grid.Length;
        int n = grid[0].Length;

        int layers = Math.Min(m, n) / 2;

        for (int layer = 0; layer < layers; layer++)
        {
            List<int> elements = new List<int>();

            int top = layer;
            int bottom = m - 1 - layer;
            int left = layer;
            int right = n - 1 - layer;

            // Top row
            for (int j = left; j <= right; j++)
            {
                elements.Add(grid[top][j]);
            }

            // Right column
            for (int i = top + 1; i <= bottom; i++)
            {
                elements.Add(grid[i][right]);
            }

            // Bottom row
            for (int j = right - 1; j >= left; j--)
            {
                elements.Add(grid[bottom][j]);
            }

            // Left column
            for (int i = bottom - 1; i > top; i--)
            {
                elements.Add(grid[i][left]);
            }

            int len = elements.Count;
            int rotation = k % len;

            int index = 0;

            // Top row
            for (int j = left; j <= right; j++)
            {
                grid[top][j] = elements[(index + rotation) % len];
                index++;
            }

            // Right column
            for (int i = top + 1; i <= bottom; i++)
            {
                grid[i][right] = elements[(index + rotation) % len];
                index++;
            }

            // Bottom row
            for (int j = right - 1; j >= left; j--)
            {
                grid[bottom][j] = elements[(index + rotation) % len];
                index++;
            }

            // Left column
            for (int i = bottom - 1; i > top; i--)
            {
                grid[i][left] = elements[(index + rotation) % len];
                index++;
            }
        }

        return grid;
    }
}
```

---

[View on LeetCode](https://leetcode.com/problems/cyclically-rotating-a-grid/)