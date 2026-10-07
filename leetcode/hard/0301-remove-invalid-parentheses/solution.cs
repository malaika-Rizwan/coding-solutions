public class Solution
{
    private HashSet<string> result = new HashSet<string>();

    public IList<string> RemoveInvalidParentheses(string s)
    {
        int leftRemove = 0;
        int rightRemove = 0;

        // Find how many '(' and ')' need to be removed
        foreach (char c in s)
        {
            if (c == '(')
            {
                leftRemove++;
            }
            else if (c == ')')
            {
                if (leftRemove > 0)
                {
                    leftRemove--;
                }
                else
                {
                    rightRemove++;
                }
            }
        }

        Backtrack(s, 0, 0, leftRemove, rightRemove, "");

        return new List<string>(result);
    }

    private void Backtrack(
        string s,
        int index,
        int balance,
        int leftRemove,
        int rightRemove,
        string current)
    {
        // Invalid balance
        if (balance < 0)
            return;

        // End of string
        if (index == s.Length)
        {
            if (balance == 0 && leftRemove == 0 && rightRemove == 0)
            {
                result.Add(current);
            }

            return;
        }

        char c = s[index];

        // Option 1: Remove current parenthesis
        if (c == '(' && leftRemove > 0)
        {
            Backtrack(
                s,
                index + 1,
                balance,
                leftRemove - 1,
                rightRemove,
                current
            );
        }

        if (c == ')' && rightRemove > 0)
        {
            Backtrack(
                s,
                index + 1,
                balance,
                leftRemove,
                rightRemove - 1,
                current
            );
        }

        // Option 2: Keep current character
        if (c == '(')
        {
            Backtrack(
                s,
                index + 1,
                balance + 1,
                leftRemove,
                rightRemove,
                current + c
            );
        }
        else if (c == ')')
        {
            Backtrack(
                s,
                index + 1,
                balance - 1,
                leftRemove,
                rightRemove,
                current + c
            );
        }
        else
        {
            // Letter
            Backtrack(
                s,
                index + 1,
                balance,
                leftRemove,
                rightRemove,
                current + c
            );
        }
    }
}