class Solution {
    public boolean isMatch(String s, String p) {
        int m = s.length();
        int n = p.length();

        boolean[][] dp = new boolean[m + 1][n + 1];

        // Empty string matches empty pattern
        dp[m][n] = true;

        // Build the table from right to left
        for (int i = m; i >= 0; i--) {
            for (int j = n - 1; j >= 0; j--) {

                boolean firstMatch = (i < m &&
                        (s.charAt(i) == p.charAt(j) || p.charAt(j) == '.'));

                // If next character is '*'
                if (j + 1 < n && p.charAt(j + 1) == '*') {

                    // Option 1: use zero occurrences
                    // Option 2: use one or more occurrences
                    dp[i][j] = dp[i][j + 2] ||
                               (firstMatch && dp[i + 1][j]);

                } else {
                    // Normal character or '.'
                    dp[i][j] = firstMatch && dp[i + 1][j + 1];
                }
            }
        }

        return dp[0][0];
    }
}