public class Solution
{
    public int MinMoves(int[] nums, int limit)
    {
        int[] diff = new int[2 * limit + 2];

        for (int i = 0; i < nums.Length / 2; i++)
        {
            int a = Math.Min(nums[i], nums[nums.Length - 1 - i]);
            int b = Math.Max(nums[i], nums[nums.Length - 1 - i]);

            int sum = a + b;

            // Initially: 2 moves for every possible sum
            diff[2] += 2;

            // From a + 1, we only need 1 move
            diff[a + 1] -= 1;

            // At the current sum, we need 0 moves
            diff[sum] -= 1;

            // After the current sum, we need 1 move again
            diff[sum + 1] += 1;

            // After b + limit, we need 2 moves again
            diff[b + limit + 1] -= 1;
        }

        int answer = nums.Length;
        int moves = 0;

        // Calculate actual number of moves for every target sum
        for (int target = 2; target <= 2 * limit; target++)
        {
            moves += diff[target];
            answer = Math.Min(answer, moves);
        }

        return answer;
    }
}