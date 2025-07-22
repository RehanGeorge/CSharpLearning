using Domain;

namespace CalculatorTest
{
    public class UnitTest1
    {
        [Fact]
        public void Sum_of_2_and_6_should_be_8()
        {
            var calculator = new Calculator();
            var result = calculator.Sum(2, 6);
            if (result != 8)
            {
                throw new Exception($"The Sum(2,2) was expected to be 4 but it's {result}");
            }
        }
    }
}