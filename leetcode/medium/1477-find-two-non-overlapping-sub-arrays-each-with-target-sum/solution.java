class Solution {
    public int minSumOfLengths(int[] arr, int target) {
        int n = arr.length;

        // best[i] = minimum length of a valid subarray
        // ending at or before index i
        int[] best = new int[n];

        int left = 0;
        int sum = 0;

        int INF = Integer.MAX_VALUE;
        int answer = INF;

        for (int right = 0; right < n; right++) {
            sum += arr[right];

            // Shrink window if sum is greater than target
            while (sum > target) {
                sum -= arr[left++];
            }

            // Copy the best answer from previous index
            if (right > 0) {
                best[right] = best[right - 1];
            } else {
                best[right] = INF;
            }

            // Found a subarray with sum == target
            if (sum == target) {
                int currentLength = right - left + 1;

                // Check if there is a previous non-overlapping subarray
                if (left > 0 && best[left - 1] != INF) {
                    answer = Math.min(
                        answer,
                        currentLength + best[left - 1]
                    );
                }

                // Store the shortest subarray ending here
                best[right] = Math.min(best[right], currentLength);
            }
        }

        return answer == INF ? -1 : answer;
    }
}