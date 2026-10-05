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