
public class Solution
{
    public int MinInsertions(string s)
    {
        int open = 0;
        int insertions = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(')
            {
                open++;
            }
            else
            {
                // If the next character is not ')',
                // insert one ')' to complete the pair.
                if (i + 1 < s.Length && s[i + 1] == ')')
                {
                    i++;
                }
                else
                {
                    insertions++;
                }

                // Match this pair with an opening '('.
                if (open > 0)
                {
                    open--;
                }
                else
                {
                    // Insert a missing opening '('.
                    insertions++;
                }
            }
        }

        // Each unmatched '(' needs two closing ')'.
        insertions += open * 2;

        return insertions;
    }
}