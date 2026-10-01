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