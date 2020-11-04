using System.Reflection.Metadata;
using Xunit;

namespace StringValidation.Facts
{
    public class NumberFacts
    {
        [Fact]
        public void CanBeZero()
        {
            var pattern = new Number();
            Assert.True(pattern.Match("0").Success());
            Assert.True(pattern.Match("0").RemainingText() == "");
        }

        [Fact]
        public void DoesntContainsLetters()
        {
            var pattern = new Number();
            Assert.False(pattern.Match("b").Success());
            Assert.True(pattern.Match("b").RemainingText() == "b");
        }

        [Fact]
        public void CanBeSingleDigit()
        {
            var pattern = new Number();
            Assert.True(pattern.Match("2").Success());
            Assert.True(pattern.Match("2").RemainingText() == "");
        }

        [Fact]
        public void CanHaveMultipleDigits()
        {
            var pattern = new Number();
            Assert.True(pattern.Match("21").Success());
            Assert.True(pattern.Match("21").RemainingText() == "");
        }

        [Fact]
        public void CantBeNull()
        {
            var pattern = new Number();
            Assert.False(pattern.Match(null).Success());
            Assert.True(pattern.Match(null).RemainingText() == null);
        }

        [Fact]
        public void CantBeEmpty()
        {
            var pattern = new Number();
            Assert.False(pattern.Match("").Success());
            Assert.True(pattern.Match("").RemainingText() == "");
        }

        [Fact]
        public void CantStartWithZero()
        {
            var pattern = new Number();
            Assert.True(pattern.Match("01").Success());
            Assert.True(pattern.Match("01").RemainingText() == "1");
        }

        [Fact]
        public void CanBeNegative()
        {
            var pattern = new Number();
            Assert.True(pattern.Match("-12").Success());
            Assert.True(pattern.Match("-12").RemainingText() == "");
        }

        [Fact]
        public void CanBeMinusZero()
        {
            var pattern = new Number();
            Assert.True(pattern.Match("-0").Success());
            Assert.True(pattern.Match("-0").RemainingText() == "");
        }

        [Fact]
        public void CanBeFractional()
        {
            var pattern = new Number();
            Assert.True(pattern.Match("3.14").Success());
            Assert.True(pattern.Match("3.14").RemainingText() == "");
        }

        [Fact]
        public void FractionCanHaveLeadingZeros()
        {
            var pattern = new Number();
            Assert.True(pattern.Match("0.00001").Success());
            Assert.True(pattern.Match("0.00001").RemainingText() == "");
            Assert.True(pattern.Match("10.00001").Success());
            Assert.True(pattern.Match("10.00001").RemainingText() == "");
        }

        [Fact]
        public void DoesNotEndWithDot()
        {
            var pattern = new Number();
            Assert.True(pattern.Match("3.").Success());
            Assert.True(pattern.Match("3.").RemainingText() == ".");
        }

        [Fact]
        public void DoesNotHaveTwoFractionParts()
        {
            var pattern = new Number();
            Assert.True(pattern.Match("3.14.12").Success());
            Assert.True(pattern.Match("3.14.12").RemainingText() == ".12");
        }

        [Fact]
        public void DecimalPartDoesNotAcceptLetters()
        {
            var pattern = new Number();
            Assert.True(pattern.Match("3.14p").Success());
            Assert.True(pattern.Match("3.14p").RemainingText() == "p");
        }

        [Fact]
        public void CanHaveExponent()
        {
            var pattern = new Number();
            Assert.True(pattern.Match("14e3").Success());
            Assert.True(pattern.Match("14e3").RemainingText() == "");
            Assert.True(pattern.Match("14E3").Success());
            Assert.True(pattern.Match("14E3").RemainingText() == "");
        }

        [Fact]
        public void ExponentCanBePositive()
        {
            var pattern = new Number();
            Assert.True(pattern.Match("14e+3").Success());
            Assert.True(pattern.Match("14e+3").RemainingText() == "");
        }

        [Fact]
        public void ExponentCanBeNegative()
        {
            var pattern = new Number();
            Assert.True(pattern.Match("14e-3").Success());
            Assert.True(pattern.Match("14e-3").RemainingText() == "");
        }

        [Fact]
        public void CanHaveFractionAndExponent()
        {
            var pattern = new Number();
            Assert.True(pattern.Match("3.14e3").Success());
            Assert.True(pattern.Match("3.14e3").RemainingText() == "");
        }

        [Fact]
        public void ExponentMustBeComplete()
        {
            var pattern = new Number();
            Assert.True(pattern.Match("3.14e+").Success());
            Assert.True(pattern.Match("3.14e+").RemainingText() == "e+");
            Assert.True(pattern.Match("14e").Success());
            Assert.True(pattern.Match("14e").RemainingText() == "e");
            Assert.True(pattern.Match("14e+").Success());
            Assert.True(pattern.Match("14e+").RemainingText() == "e+");
            Assert.True(pattern.Match("14e-").Success());
            Assert.True(pattern.Match("14e-").RemainingText() == "e-");
        }

        [Fact]
        public void ExponentDoesNotAllowLetters()
        {
            var pattern = new Number();
            Assert.True(pattern.Match("3.14e+2x2").Success());
            Assert.True(pattern.Match("3.14e+2x2").RemainingText() == "x2");
        }

        [Fact]
        public void DoesNotHaveTwoExponents()
        {
            var pattern = new Number();
            Assert.True(pattern.Match("14e23E2").Success());
            Assert.True(pattern.Match("14e23E2").RemainingText() == "E2");
        }

        [Fact]
        public void ExponentIsAfterTheFraction()
        {
            var pattern = new Number();
            Assert.True(pattern.Match("14e2.345").Success());
            Assert.True(pattern.Match("14e2.345").RemainingText() == ".345");
        }

        [Fact]
        public void SignCanBeOnlyAfterExponent()
        {
            var pattern = new Number();
            Assert.True(pattern.Match("14.-3e45").Success());
            Assert.True(pattern.Match("14.-3e45").RemainingText() == ".-3e45");
        }
    }
}
