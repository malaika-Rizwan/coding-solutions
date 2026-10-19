
public class Solution
{
    public bool CanReach(string s, int minJump, int maxJump)
    {
        int n = s.Length;

        bool[] dp = new bool[n];
        dp[0] = true;

        int reachable = 0;

        for (int i = 1; i < n; i++)
        {
            // Add the index that has just entered
            // the valid jumping range
            int add = i - minJump;

            if (add >= 0 && dp[add])
            {
                reachable++;
            }

            // Remove the index that has left
            // the valid jumping range
            int remove = i - maxJump - 1;

            if (remove >= 0 && dp[remove])
            {
                reachable--;
            }

            // We can reach i if a previous valid
            // index can jump to it and s[i] is '0'
            dp[i] = s[i] == '0' && reachable > 0;
        }

        return dp[n - 1];
    }
}
