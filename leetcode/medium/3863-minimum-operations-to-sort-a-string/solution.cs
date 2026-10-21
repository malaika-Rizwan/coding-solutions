
public class Solution
{
    public int MinOperations(string s)
    {
        int n = s.Length;
        bool sorted = true;

        for (int i = 1; i < n; i++)
        {
            if (s[i] < s[i - 1])
            {
                sorted = false;
                break;
            }
        }

        if (sorted)
            return 0;

        if (n == 2)
            return -1;

        char minChar = s[0];
        char maxChar = s[0];

        for (int i = 1; i < n; i++)
        {
            minChar = (char)Math.Min(minChar, s[i]);
            maxChar = (char)Math.Max(maxChar, s[i]);
        }

        // One operation is enough
        if (s[0] == minChar || s[n - 1] == maxChar)
            return 1;

        // Check whether min or max occurs inside the string
        for (int i = 1; i < n - 1; i++)
        {
            if (s[i] == minChar || s[i] == maxChar)
                return 2;
        }

        // Minimum is at the end and maximum at the beginning
        return 3;
    }
}
