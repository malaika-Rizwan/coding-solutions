public class Solution
{
    public bool CheckValidString(string s)
    {
        int minOpen = 0;
        int maxOpen = 0;

        foreach (char c in s)
        {
            if (c == '(')
            {
                minOpen++;
                maxOpen++;
            }
            else if (c == ')')
            {
                minOpen--;
                maxOpen--;
            }
            else // '*'
            {
                minOpen--;
                maxOpen++;
            }

            // We cannot have negative possible open brackets
            if (maxOpen < 0)
            {
                return false;
            }

            minOpen = Math.Max(0, minOpen);
        }

        return minOpen == 0;
    }
}