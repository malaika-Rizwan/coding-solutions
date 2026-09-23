class Solution {
    public int minOperations(int[] nums, int x) {

        int n = nums.length;

        // Calculate total sum
        int totalSum = 0;

        for (int num : nums) {
            totalSum += num;
        }

        // Sum of the subarray we want to keep
        int target = totalSum - x;

        // If target is negative, impossible
        if (target < 0) {
            return -1;
        }

        // If target is 0, remove everything
        if (target == 0) {
            return n;
        }

        int left = 0;
        int currentSum = 0;
        int maxLength = -1;

        for (int right = 0; right < n; right++) {

            currentSum += nums[right];

            // Shrink window if sum becomes too large
            while (currentSum > target) {
                currentSum -= nums[left];
                left++;
            }

            // Found a valid subarray
            if (currentSum == target) {
                maxLength = Math.max(
                    maxLength,
                    right - left + 1
                );
            }
        }

        // No valid subarray
        if (maxLength == -1) {
            return -1;
        }

        return n - maxLength;
    }
}