public class Solution
{
    public string CountAndSay(int n)
    {
        string result = "1";

        for (int i = 2; i <= n; i++)
        {
            result = Say(result);
        }

        return result;
    }

    private string Say(string s)
    {
        string result = "";
        int count = 1;

        for (int i = 1; i < s.Length; i++)
        {
            if (s[i] == s[i - 1])
            {
                count++;
            }
            else
            {
                result += count.ToString() + s[i - 1];
                count = 1;
            }
        }

        // Add the last group
        result += count.ToString() + s[s.Length - 1];

        return result;
    }
}