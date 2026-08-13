public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r)
    {
        return r.Expreal(realNumber);
    }
}

public struct RationalNumber
{
    private int numerator;
    private int denominator;

    public RationalNumber(int numerator, int denominator)
    {
        if (denominator == 0)
            throw new ArgumentException("Denominator cannot be zero.");

        if (denominator < 0)
        {
            numerator = -numerator;
            denominator = -denominator;
        }

        int a = Math.Abs(numerator);
        int b = Math.Abs(denominator);

        while (b != 0)
        {
            int remainder = a % b;
            a = b;
            b = remainder;
        }

        int gcd = a;

        if (gcd != 0)
        {
            numerator /= gcd;
            denominator /= gcd;
        }

        this.numerator = numerator;
        this.denominator = denominator;
    }

    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
    {
        return new RationalNumber(r1.numerator * r2.denominator + r2.numerator * r1.denominator,
            r1.denominator * r2.denominator);
    }

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
    {
        return new RationalNumber(r1.numerator * r2.denominator - r2.numerator * r1.denominator, 
        r1.denominator * r2.denominator);
    }

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
    {
        return new RationalNumber(r1.numerator * r2.numerator, r1.denominator * r2.denominator);
    }

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
    {
        if (r2.numerator == 0)
            throw new DivideByZeroException();

        return new RationalNumber(r1.numerator * r2.denominator, r1.denominator * r2.numerator);
    }

    public RationalNumber Abs()
    {
        return new RationalNumber(Math.Abs(numerator), denominator);
    }

    public RationalNumber Reduce()
    {
        return new RationalNumber(numerator, denominator);
    }

    public RationalNumber Exprational(int power)
    {
        if (power == 0)
            return new RationalNumber(1, 1);

        if (power > 0){
            return new RationalNumber((int)Math.Pow(numerator, power), (int)Math.Pow(denominator, power));
        }

        if (numerator == 0)
            throw new DivideByZeroException();

        int positivePower = -power;

        return new RationalNumber((int)Math.Pow(denominator, positivePower),(int)Math.Pow(numerator, positivePower));
    }

    public double Expreal(int baseNumber)
    {
        return Math.Pow(
            baseNumber,
            (double)numerator / denominator
        );
    }
}