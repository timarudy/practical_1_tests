namespace ConsoleApp1
{
    public class FractionalNumber
    {
        private readonly int _numerator;
        private readonly int _denominator;

        public FractionalNumber(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Denominator cannot be zero.");
            }
            
            _numerator = numerator;
            _denominator = denominator;
        }

        public FractionalNumber()
        {
            _numerator = 1;
            _denominator = 1;
        }

        public FractionalNumber(FractionalNumber fractionalNumber)
        {
            _numerator = fractionalNumber.GetNumerator();
            _denominator = fractionalNumber.GetDenominator();
        }

        public FractionalNumber AddFractionalNumber(FractionalNumber fractionalNumber)
        {
            if (_denominator == fractionalNumber.GetDenominator())
            {
                return Simplify(new FractionalNumber(_numerator + fractionalNumber.GetNumerator(), _denominator));
            }

            int numerator = _numerator * fractionalNumber.GetDenominator() + fractionalNumber.GetNumerator() * _denominator;
            int denominator = _denominator * fractionalNumber.GetDenominator();

            return Simplify(new FractionalNumber(numerator, denominator));
        }
        
        public FractionalNumber SubtractFractionalNumber(FractionalNumber fractionalNumber)
        {
            if (_denominator == fractionalNumber.GetDenominator())
            {
                return Simplify(new FractionalNumber(_numerator - fractionalNumber.GetNumerator(), _denominator));
            }

            int numerator = _numerator * fractionalNumber.GetDenominator() - fractionalNumber.GetNumerator() * _denominator;
            int denominator = _denominator * fractionalNumber.GetDenominator();

            return Simplify(new FractionalNumber(numerator, denominator));
        }

        public FractionalNumber MultiplyFractionalNumber(FractionalNumber fractionalNumber)
        {
            int numerator = _numerator * fractionalNumber.GetNumerator();
            int denominator = _denominator * fractionalNumber.GetDenominator();

            return Simplify(new FractionalNumber(numerator, denominator));
        }

        public FractionalNumber DivideFractionalNumber(FractionalNumber fractionalNumber)
        {
            if (fractionalNumber.GetNumerator() == 0)
            {
                throw new DivideByZeroException("Cannot divide by a fraction with a numerator of zero.");
            }

            int numerator = _numerator * fractionalNumber.GetDenominator();
            int denominator = _denominator * fractionalNumber.GetNumerator();

            return Simplify(new FractionalNumber(numerator, denominator));
        }

        public override bool Equals(object? fractionalNumber)
        {
            if (fractionalNumber == null) return false;
            
            FractionalNumber simplifiedThis = Simplify(this);
            FractionalNumber simplifiedOther = Simplify(fractionalNumber as FractionalNumber);

            return simplifiedThis.GetNumerator() == simplifiedOther.GetNumerator() &&
                   simplifiedThis.GetDenominator() == simplifiedOther.GetDenominator();
        }
        
        public FractionalNumber AddInteger(int integer)
        {
            return Simplify(new FractionalNumber(_numerator + integer * _denominator, _denominator));
        }

        public FractionalNumber MultiplyInteger(int integer)
        {
            return Simplify(new FractionalNumber(_numerator * integer, _denominator));
        }

        public override string ToString() => 
            $"{_numerator}/{_denominator}";

        private FractionalNumber Simplify(FractionalNumber? fractionalNumber)
        {
            int gcd = GCD(fractionalNumber!.GetNumerator(), fractionalNumber.GetDenominator());
            int simplifiedNumerator = fractionalNumber.GetNumerator() / gcd;
            int simplifiedDenominator = fractionalNumber.GetDenominator() / gcd;

            return new FractionalNumber(simplifiedNumerator, simplifiedDenominator);
        }

        private int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public int GetDenominator() =>
            _denominator;

        public int GetNumerator() =>
            _numerator;
    }
}
