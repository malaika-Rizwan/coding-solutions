public class Solution
{
    public int MinimumEffort(int[][] tasks)
    {
        // Sort by (minimum - actual) in descending order
        Array.Sort(tasks, (a, b) =>
        {
            int diffA = a[1] - a[0];
            int diffB = b[1] - b[0];

            return diffB.CompareTo(diffA);
        });

        int energy = 0;
        int currentEnergy = 0;

        foreach (int[] task in tasks)
        {
            int actual = task[0];
            int minimum = task[1];

            // Energy needed before starting this task
            energy = Math.Max(energy, currentEnergy + minimum);

            // Spend the actual energy
            currentEnergy += actual;
        }

        return energy;
    }
}