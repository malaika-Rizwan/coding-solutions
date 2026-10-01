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

**Language:** Java  
**Runtime:** 2 ms (beats 96.91%)  
**Memory:** 47.5 MB (beats 38.20%)  
**Submitted:** 2026-10-01T16:38:11.043Z  

```java
class Solution {
    public int[][] rotateGrid(int[][] grid, int k) {
        int m = grid.length;
        int n = grid[0].length;

        int layers = Math.min(m, n) / 2;

        for (int layer = 0; layer < layers; layer++) {

            // Number of elements in this layer
            int height = m - 2 * layer;
            int width = n - 2 * layer;

            int len = 2 * (height + width) - 4;

            int[] ring = new int[len];

            int index = 0;

            // Top row: left -> right
            for (int j = layer; j < n - layer; j++) {
                ring[index++] = grid[layer][j];
            }

            // Right column: top -> bottom
            for (int i = layer + 1; i < m - layer; i++) {
                ring[index++] = grid[i][n - layer - 1];
            }

            // Bottom row: right -> left
            for (int j = n - layer - 2; j >= layer; j--) {
                ring[index++] = grid[m - layer - 1][j];
            }

            // Left column: bottom -> top
            for (int i = m - layer - 2; i > layer; i--) {
                ring[index++] = grid[i][layer];
            }

            // Effective rotation
            int shift = k % len;

            index = 0;

            // Put rotated values back

            // Top row
            for (int j = layer; j < n - layer; j++) {
                grid[layer][j] =
                    ring[(index++ + shift) % len];
            }

            // Right column
            for (int i = layer + 1; i < m - layer; i++) {
                grid[i][n - layer - 1] =
                    ring[(index++ + shift) % len];
            }

            // Bottom row
            for (int j = n - layer - 2; j >= layer; j--) {
                grid[m - layer - 1][j] =
                    ring[(index++ + shift) % len];
            }

            // Left column
            for (int i = m - layer - 2; i > layer; i--) {
                grid[i][layer] =
                    ring[(index++ + shift) % len];
            }
        }

        return grid;
    }
}
```

---

[View on LeetCode](https://leetcode.com/problems/cyclically-rotating-a-grid/)