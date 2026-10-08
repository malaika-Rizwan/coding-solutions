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

            // Initially, every sum requires 2 moves
            diff[2] += 2;

            // From a + 1, it becomes possible with 1 move
            diff[a + 1] -= 1;

            // At the original sum, it requires 0 moves
            diff[sum] -= 1;

            // After the original sum, it goes back to 1 move
            diff[sum + 1] += 1;

            // After b + limit, it goes back to 2 moves
            diff[b + limit + 1] += 1; // FIXED
        }

        int moves = 0;
        int answer = nums.Length;

        for (int target = 2; target <= 2 * limit; target++)
        {
            moves += diff[target];
            answer = Math.Min(answer, moves);
        }

        return answer;
    }
}