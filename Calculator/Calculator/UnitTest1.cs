namespace Calculator
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            if (Sum(2, 3) != 5)
            {
                throw new Exception("Sum(2, 3) should be 5");
            }

        }

        int Sum(int left, int right)
        {
            return left + right;
        }
    }
}