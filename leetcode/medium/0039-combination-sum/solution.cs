public class Solution
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        List<IList<int>> result = new List<IList<int>>();
        List<int> current = new List<int>();

        Backtrack(candidates, target, 0, current, result);

        return result;
    }

    private void Backtrack(
        int[] candidates,
        int remaining,
        int start,
        List<int> current,
        List<IList<int>> result)
    {
        // Target reached
        if (remaining == 0)
        {
            result.Add(new List<int>(current));
            return;
        }

        // Try candidates
        for (int i = start; i < candidates.Length; i++)
        {
            int candidate = candidates[i];

            // If candidate is too large, skip it
            if (candidate > remaining)
                continue;

            // Choose
            current.Add(candidate);

            // i, not i + 1
            // because we can reuse the same number
            Backtrack(
                candidates,
                remaining - candidate,
                i,
                current,
                result
            );

            // Undo choice
            current.RemoveAt(current.Count - 1);
        }
    }
}