public class Solution
{
    public int MinAddToMakeValid(string s)
    {
        int open = 0;
        int add = 0;

        foreach (char c in s)
        {
            if (c == '(')
            {
                open++;
            }
            else
            {
                if (open > 0)
                {
                    open--;
                }
                else
                {
                    add++;
                }
            }
        }

        return add + open;
    }
}