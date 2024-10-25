using ConsoleApp1;

namespace practical_1_tests;

public class Tests
{
    [TestCase(1, 0)]
    [TestCase(1, 2)]
    public void FractionalNumber_Constructor_ShouldThrowExceptionForZeroDenominator(
        int numerator, int denominator)
    {
        if (denominator == 0)
        {
            Assert.Throws<ArgumentException>(() => new FractionalNumber(numerator, denominator), "Denominator cannot be zero.");
        }
        else
        {
            Assert.DoesNotThrow(() => new FractionalNumber(numerator, denominator));
        }
    }
    
    [TestCase(1, 2, 1, 3, 5, 6)]
    [TestCase(1, 4, 3, 4, 1, 1)]
    [TestCase(1, 2, 1, 2, 1, 1)]
    public void FractionalNumber_ShouldAddFractionalNumber(
        int numerator1, int denominator1,
        int numerator2, int denominator2,
        int expectedNumerator, int expectedDenominator)
    {
        // Arrange
        FractionalNumber fraction1 = new FractionalNumber(numerator1, denominator1);
        FractionalNumber fraction2 = new FractionalNumber(numerator2, denominator2);

        // Act
        FractionalNumber result = fraction1.AddFractionalNumber(fraction2);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.GetNumerator(), Is.EqualTo(expectedNumerator));
            Assert.That(result.GetDenominator(), Is.EqualTo(expectedDenominator));
        });
    }

    [TestCase(7, 10, 1, 3, 11, 30)]
    [TestCase(5, 6, 1, 6, 2, 3)]
    [TestCase(3, 4, 1, 4, 1, 2)]
    [TestCase(1, 2, 1, 2, 0, 1)]
    public void FractionalNumber_ShouldSubtractFractionalNumber(
        int numerator1, int denominator1,
        int numerator2, int denominator2,
        int expectedNumerator, int expectedDenominator)
    {
        // Arrange
        FractionalNumber fraction1 = new FractionalNumber(numerator1, denominator1);
        FractionalNumber fraction2 = new FractionalNumber(numerator2, denominator2);

        // Act
        FractionalNumber result = fraction1.SubtractFractionalNumber(fraction2);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.GetNumerator(), Is.EqualTo(expectedNumerator));
            Assert.That(result.GetDenominator(), Is.EqualTo(expectedDenominator));
        });
    }
    
    [TestCase(1, 2, 1, 3, 1, 6)]
    [TestCase(2, 3, 3, 4, 1, 2)]
    [TestCase(1, 2, 2, 3, 1, 3)]
    public void FractionalNumber_ShouldMultiplyFractionalNumber(
        int numerator1, int denominator1,
        int numerator2, int denominator2,
        int expectedNumerator, int expectedDenominator)
    {
        // Arrange
        FractionalNumber fraction1 = new FractionalNumber(numerator1, denominator1);
        FractionalNumber fraction2 = new FractionalNumber(numerator2, denominator2);

        // Act
        FractionalNumber result = fraction1.MultiplyFractionalNumber(fraction2);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.GetNumerator(), Is.EqualTo(expectedNumerator));
            Assert.That(result.GetDenominator(), Is.EqualTo(expectedDenominator));
        });
    }
    
    [TestCase(1, 2, 1, 3, 3, 2)]
    [TestCase(2, 3, 1, 4, 8, 3)]
    [TestCase(1, 2, 2, 1, 1, 4)]
    public void FractionalNumber_ShouldDivideFractionalNumber(
        int numerator1, int denominator1,
        int numerator2, int denominator2,
        int expectedNumerator, int expectedDenominator)
    {
        // Arrange
        FractionalNumber fraction1 = new FractionalNumber(numerator1, denominator1);
        FractionalNumber fraction2 = new FractionalNumber(numerator2, denominator2);

        // Act
        FractionalNumber result = fraction1.DivideFractionalNumber(fraction2);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.GetNumerator(), Is.EqualTo(expectedNumerator));
            Assert.That(result.GetDenominator(), Is.EqualTo(expectedDenominator));
        });
    }
    
    [TestCase(1, 2, 1, 3)]
    [TestCase(2, 3, 1, 4)]
    [TestCase(1, 2, 2, 1)]
    public void FractionalNumber_DivideFractionalNumber_ShouldThrowExceptionForZeroDenominator(
        int numerator1, int denominator1,
        int numerator2, int denominator2)
    {
        // Arrange
        FractionalNumber fraction1 = new FractionalNumber(numerator1, denominator1);
        FractionalNumber fraction2 = new FractionalNumber(numerator2, denominator2);

        // Act and assert
        if (numerator2 == 0)
        {
            Assert.Throws<DivideByZeroException>(() => fraction1.DivideFractionalNumber(fraction2));
        }
        else
        {
            Assert.DoesNotThrow(() => fraction1.DivideFractionalNumber(fraction2));
        }
    }
    
    [TestCase(1, 2, 2, 4, true)]
    [TestCase(1, 3, 1, 3, true)]
    [TestCase(1, 2, 3, 6, true)]
    [TestCase(2, 5, 3, 5, false)]
    public void FractionalNumber_ShouldCheckEquality(
        int numerator1, int denominator1,
        int numerator2, int denominator2,
        bool expected)
    {
        // Arrange
        FractionalNumber fraction1 = new FractionalNumber(numerator1, denominator1);
        FractionalNumber fraction2 = new FractionalNumber(numerator2, denominator2);

        // Act
        bool result = fraction1.Equals(fraction2);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    
    [TestCase(1, 2, 1, 3, 2)]
    [TestCase(3, 4, 2, 11, 4)]
    [TestCase(1, 3, 5, 16, 3)]
    public void FractionalNumber_ShouldAddInteger(
        int numerator, int denominator,
        int integerToAdd, int expectedNumerator, int expectedDenominator)
    {
        // Arrange
        FractionalNumber fraction = new FractionalNumber(numerator, denominator);

        // Act
        FractionalNumber result = fraction.AddInteger(integerToAdd);

        Assert.Multiple(() =>
        {
            // Assert
            Assert.That(result.GetNumerator(), Is.EqualTo(expectedNumerator));
            Assert.That(result.GetDenominator(), Is.EqualTo(expectedDenominator));
        });
    }
    
    [TestCase(1, 2, 2, 1, 1)]
    [TestCase(3, 4, 2, 3, 2)]
    [TestCase(2, 5, 3, 6, 5)]
    public void FractionalNumber_ShouldMultiplyInteger(
        int numerator, int denominator,
        int integerToMultiply, int expectedNumerator, int expectedDenominator)
    {
        // Arrange
        FractionalNumber fraction = new FractionalNumber(numerator, denominator);

        // Act
        FractionalNumber result = fraction.MultiplyInteger(integerToMultiply);

        Assert.Multiple(() =>
        {
            // Assert
            Assert.That(result.GetNumerator(), Is.EqualTo(expectedNumerator));
            Assert.That(result.GetDenominator(), Is.EqualTo(expectedDenominator));
        });
    }
}