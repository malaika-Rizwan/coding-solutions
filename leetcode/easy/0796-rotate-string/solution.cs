public class Solution
{
    public bool RotateString(string s, string goal)
    {
        if (s.Length != goal.Length)
        {
            return false;
        }

        string combined = s + s;

        return combined.Contains(goal);
    }
}