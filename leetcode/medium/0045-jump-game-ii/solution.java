
class Solution {
    public int jump(int[] nums) {

        int jumps = 0;
        int currentEnd = 0;
        int farthest = 0;

        for (int i = 0; i < nums.length - 1; i++) {

            // Find the farthest reachable index
            farthest = Math.max(farthest, i + nums[i]);

            // We have reached the end of current range
            if (i == currentEnd) {

                jumps++;

                currentEnd = farthest;
            }
        }

        return jumps;
    }
}