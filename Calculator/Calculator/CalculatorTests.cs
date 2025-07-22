using Domain;
using FluentAssertions;

namespace CalculatorTest
{
    public class CalculatorTests
    {
        [Fact]
        public void Sum_of_2_and_6_should_be_8()
        => new Calculator().Sum(2, 6).Should().Be(8);

        [Fact]
        public void Sum_of_2_and_6_should_not_be_7()
            => new Calculator().Sum(2, 6).Should().NotBe(7);
    }
}