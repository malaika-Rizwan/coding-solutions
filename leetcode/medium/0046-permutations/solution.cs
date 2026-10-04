public class Solution
{
    public IList<IList<int>> Permute(int[] nums)
    {
        List<IList<int>> result = new List<IList<int>>();
        List<int> current = new List<int>();
        bool[] used = new bool[nums.Length];

        Backtrack(nums, current, used, result);

        return result;
    }

    private void Backtrack(
        int[] nums,
        List<int> current,
        bool[] used,
        List<IList<int>> result)
    {
        // We have created one complete permutation
        if (current.Count == nums.Length)
        {
            result.Add(new List<int>(current));
            return;
        }

        // Try every number
        for (int i = 0; i < nums.Length; i++)
        {
            // Skip numbers already used
            if (used[i])
                continue;

            // Choose
            current.Add(nums[i]);
            used[i] = true;

            // Explore
            Backtrack(nums, current, used, result);

            // Undo
            current.RemoveAt(current.Count - 1);
            used[i] = false;
        }
    }
}