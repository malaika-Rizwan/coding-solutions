public class Solution
{
    public int ScoreOfParentheses(string s)
    {
        Stack<int> stack = new Stack<int>();
        stack.Push(0);

        foreach (char c in s)
        {
            if (c == '(')
            {
                // Start a new level
                stack.Push(0);
            }
            else
            {
                // Get the score inside the current parentheses
                int innerScore = stack.Pop();

                // () = 1
                // (A) = 2 * A
                int score = innerScore == 0 ? 1 : 2 * innerScore;

                // Add this score to the outer level
                stack.Push(stack.Pop() + score);
            }
        }

        return stack.Pop();
    }
}