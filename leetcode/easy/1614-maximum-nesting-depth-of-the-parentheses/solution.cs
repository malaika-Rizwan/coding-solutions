public class Solution
{
    public string ReverseParentheses(string s)
    {
        Stack<StringBuilder> stack = new Stack<StringBuilder>();

        StringBuilder current = new StringBuilder();

        foreach (char ch in s)
        {
            if (ch == '(')
            {
                // Save the current string
                stack.Push(current);

                // Start a new string
                current = new StringBuilder();
            }
            else if (ch == ')')
            {
                // Reverse the substring inside parentheses
                Reverse(current);

                // Get the string before '('
                StringBuilder previous = stack.Pop();

                // Add reversed substring to previous string
                previous.Append(current);

                current = previous;
            }
            else
            {
                // Add normal character
                current.Append(ch);
            }
        }

        return current.ToString();
    }

    private void Reverse(StringBuilder sb)
    {
        int left = 0;
        int right = sb.Length - 1;

        while (left < right)
        {
            char temp = sb[left];
            sb[left] = sb[right];
            sb[right] = temp;

            left++;
            right--;
        }
    }
}