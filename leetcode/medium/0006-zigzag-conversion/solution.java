class Solution {
    public String convert(String s, int numRows) {

        // If there is only one row, no zigzag is needed
        if (numRows == 1 || numRows >= s.length()) {
            return s;
        }

        StringBuilder[] rows = new StringBuilder[numRows];

        // Create StringBuilder for each row
        for (int i = 0; i < numRows; i++) {
            rows[i] = new StringBuilder();
        }

        int currentRow = 0;
        boolean goingDown = false;

        // Put each character into the correct row
        for (char c : s.toCharArray()) {

            rows[currentRow].append(c);

            // Change direction at top and bottom
            if (currentRow == 0 || currentRow == numRows - 1) {
                goingDown = !goingDown;
            }

            if (goingDown) {
                currentRow++;
            } else {
                currentRow--;
            }
        }

        // Combine all rows
        StringBuilder result = new StringBuilder();

        for (StringBuilder row : rows) {
            result.append(row);
        }

        return result.toString();
    }
}