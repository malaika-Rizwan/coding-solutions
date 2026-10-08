public class Solution
{
    public string RemoveOuterParentheses(string s)
    {
        StringBuilder result = new StringBuilder();
        int depth = 0;

        foreach (char c in s)
        {
            if (c == '(')
            {
                // If depth > 0, this is NOT an outermost '('
                if (depth > 0)
                {
                    result.Append(c);
                }

                depth++;
            }
            else
            {
                depth--;

                // If depth > 0, this is NOT an outermost ')'
                if (depth > 0)
                {
                    result.Append(c);
                }
            }
        }

        return result.ToString();
    }
}