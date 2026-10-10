
public class Solution
{
    public double MyPow(double x, int n)
    {
        long power = n;
        bool negative = power < 0;

        power = Math.Abs(power);

        double result = 1.0;

        while (power > 0)
        {
            if ((power & 1) == 1)
            {
                result *= x;
            }

            x *= x;
            power >>= 1;
        }

        return negative ? 1.0 / result : result;
    }
}
