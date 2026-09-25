public class Solution
{
    public IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        List<IList<int>> result = new List<IList<int>>();
        List<int> current = new List<int>();

        Array.Sort(candidates);

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

        for (int i = start; i < candidates.Length; i++)
        {
            // Skip duplicate values at the same level
            if (i > start && candidates[i] == candidates[i - 1])
                continue;

            // Since array is sorted
            if (candidates[i] > remaining)
                break;

            // Choose
            current.Add(candidates[i]);

            // i + 1 because each element can only be used once
            Backtrack(
                candidates,
                remaining - candidates[i],
                i + 1,
                current,
                result
            );

            // Undo choice
            current.RemoveAt(current.Count - 1);
        }
    }
}