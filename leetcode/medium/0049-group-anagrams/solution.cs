public class Solution
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();

        foreach (string str in strs)
        {
            // Convert string to character array
            char[] chars = str.ToCharArray();

            // Sort the characters
            Array.Sort(chars);

            // Convert back to string
            string key = new string(chars);

            // If this key doesn't exist, create a new list
            if (!map.ContainsKey(key))
            {
                map[key] = new List<string>();
            }

            // Add the original string to its group
            map[key].Add(str);
        }

        return new List<IList<string>>(map.Values);
    }
}