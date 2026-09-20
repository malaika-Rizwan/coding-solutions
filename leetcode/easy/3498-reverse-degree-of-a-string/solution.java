class Solution {
    public int reverseDegree(String s) {
        int sum = 0;

        for (int i = 0; i < s.length(); i++) {
            char c = s.charAt(i);

            // Reverse alphabet position
            int reversePosition = 'z' - c + 1;

            // String position is i + 1
            sum += reversePosition * (i + 1);
        }

        return sum;
    }
}