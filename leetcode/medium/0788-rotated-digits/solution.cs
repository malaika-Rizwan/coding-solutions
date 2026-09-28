public class Solution
{
    public int RotatedDigits(int n)
    {
        int count = 0;

        for (int i = 1; i <= n; i++)
        {
            int x = i;
            bool isValid = true;
            bool isDifferent = false;

            while (x > 0)
            {
                int digit = x % 10;

                // Invalid digits
                if (digit == 3 || digit == 4 || digit == 7)
                {
                    isValid = false;
                    break;
                }

                // Digits that change after rotation
                if (digit == 2 || digit == 5 ||
                    digit == 6 || digit == 9)
                {
                    isDifferent = true;
                }

                x /= 10;
            }

            if (isValid && isDifferent)
            {
                count++;
            }
        }

        return count;
    }
}