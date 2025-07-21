using Domain;

namespace CalculatorTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var calculator = new Calculator();
            if (calculator.Sum(2, 3) != 5)
            {
                throw new Exception("Sum(2, 3) should be 5");
            }

        }


    }
}