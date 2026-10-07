public class Solution
{
    public int[] SeparateDigits(int[] nums)
    {
        List<int> answer = new List<int>();

        foreach (int number in nums)
        {
            int num = number;
            List<int> digits = new List<int>();

            while (num > 0)
            {
                int digit = num % 10;
                digits.Add(digit);
                num = num / 10;
            }

            digits.Reverse();

            answer.AddRange(digits);
        }

        return answer.ToArray();
    }
}