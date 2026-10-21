
public class Solution
{
    public int MinOperations(string s)
    {
        int n = s.Length;

        // Already sorted
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

        // A single character cannot be changed
        if (n == 1)
            return -1;

        // Length 2: the only proper substring that can
        // change the string is the whole string, which is forbidden.
        if (n == 2)
            return -1;

        // If the first character is the smallest and the last
        // character is the largest, sort the middle substring.
        char minChar = 'z';
        char maxChar = 'a';

        foreach (char c in s)
        {
            minChar = (char)Math.Min(minChar, c);
            maxChar = (char)Math.Max(maxChar, c);
        }

        if (s[0] == minChar && s[n - 1] == maxChar)
            return 1;

        // If either endpoint is already in its correct extreme
        // position, two operations are sufficient.
        if (s[0] == minChar || s[n - 1] == maxChar)
            return 2;

        // If the minimum is at the end and the maximum at the
        // beginning, three operations are sufficient.
        if (s[0] == maxChar && s[n - 1] == minChar)
            return 3;

        return 2;
    }
}
