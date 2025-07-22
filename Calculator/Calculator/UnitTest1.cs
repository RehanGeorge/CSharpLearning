using Domain;
using FluentAssertions;

namespace CalculatorTest
{
    public class UnitTest1
    {
        [Fact]
        public void Sum_of_2_and_6_should_be_8()
        {
            var calculator = new Calculator();
            var result = calculator.Sum(2, 6);

            result.Should().Be(8);
        }
    }
}