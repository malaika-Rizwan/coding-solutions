
public class Solution
{
    public int LongestCommonPrefix(int[] arr1, int[] arr2)
    {
        HashSet<int> prefixes = new HashSet<int>();

        foreach (int num in arr1)
        {
            int n = num;

            while (n > 0)
            {
                prefixes.Add(n);
                n /= 10;
            }
        }

        int maxLength = 0;

        foreach (int num in arr2)
        {
            int n = num;

            while (n > 0)
            {
                if (prefixes.Contains(n))
                {
                    maxLength = Math.Max(maxLength, n.ToString().Length);
                    break;
                }

                n /= 10;
            }
        }

        return maxLength;
    }
}
