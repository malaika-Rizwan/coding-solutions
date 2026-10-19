
public class Solution
{
    public int NumberOfSpecialChars(string word)
    {
        int[] lower = new int[26];
        int[] upper = new int[26];

        Array.Fill(lower, -1);
        Array.Fill(upper, -1);

        for (int i = 0; i < word.Length; i++)
        {
            char c = word[i];

            if (char.IsLower(c))
            {
                lower[c - 'a'] = i;
            }
            else
            {
                if (upper[c - 'A'] == -1)
                {
                    upper[c - 'A'] = i;
                }
            }
        }

        int count = 0;

        for (int i = 0; i < 26; i++)
        {
            if (lower[i] != -1 &&
                upper[i] != -1 &&
                lower[i] < upper[i])
            {
                count++;
            }
        }

        return count;
    }
}
