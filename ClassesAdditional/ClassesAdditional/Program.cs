using System.Diagnostics;

namespace ClassesAdditional
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int result = 0;

            Debug.WriteLine("Main method is running");

            Console.WriteLine("Enter your age:");
            GetUserAge(Console.ReadLine());

            try
            {
                Console.WriteLine("Please enter a number");
                int num1 = int.Parse(Console.ReadLine());
                int num2 = 3;

                result = num2 / num1;
            } catch (DivideByZeroException ex)
            {
                Console.WriteLine("DON'T DIVIDE BY ZERO!!! " + ex.Message);
            } catch(FormatException ex)
            {
                Console.WriteLine("You didn't enter a number " + ex.Message);
            } catch (OverflowException ex)
            {
                Console.WriteLine("Number too high!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                // This is only executed during "Debugging"
                Debug.WriteLine(ex.ToString());
            }
            finally
            {
                Console.WriteLine($"Result: {result}");
            }
        }

        static int GetUserAge(string input)
        {
            int age;
            if (!int.TryParse(input, out age))
            {
                throw new Exception("You didn't enter a valid age.");
            }
            if (age < 0 || age > 120)
            {
                throw new Exception("Your age must be between 0 and 120.");
            }
            return age;
        }
        
        static void LevelOne()
        {
            LevelTwo();
        }

        static void LevelTwo()
        {
            throw new Exception("Something went wrong!");
        }
    }
}
