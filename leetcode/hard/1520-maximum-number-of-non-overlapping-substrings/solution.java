import java.util.*;

class Solution {
    public List<String> maxNumOfSubstrings(String s) {
        List<String> result = new ArrayList<>();

        int n = s.length();

        // first[i] = first occurrence of character i
        // last[i]  = last occurrence of character i
        int[] first = new int[26];
        int[] last = new int[26];

        Arrays.fill(first, n);
        Arrays.fill(last, -1);

        // Find first and last occurrence of every character
        for (int i = 0; i < n; i++) {
            int c = s.charAt(i) - 'a';

            first[c] = Math.min(first[c], i);
            last[c] = i;
        }

        List<int[]> intervals = new ArrayList<>();

        // Try to create a valid substring for every character
        for (int c = 0; c < 26; c++) {

            if (last[c] == -1) {
                continue; // character doesn't exist
            }

            int left = first[c];
            int right = last[c];

            boolean valid = true;

            for (int i = left; i <= right; i++) {
                int current = s.charAt(i) - 'a';

                // This character appeared before our left boundary.
                // Therefore, we would have to include that occurrence too.
                if (first[current] < left) {
                    valid = false;
                    break;
                }

                // Expand the interval to include ALL occurrences
                // of this character.
                right = Math.max(right, last[current]);
            }

            if (valid) {
                intervals.add(new int[]{left, right});
            }
        }

        // Sort intervals by ending position
        intervals.sort((a, b) -> Integer.compare(a[1], b[1]));

        int previousEnd = -1;

        // Greedily choose intervals with earliest ending position
        for (int[] interval : intervals) {

            int left = interval[0];
            int right = interval[1];

            if (left > previousEnd) {
                result.add(s.substring(left, right + 1));
                previousEnd = right;
            }
        }

        return result;
    }
}