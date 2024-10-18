using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the first number:");
        string input1 = Console.ReadLine();

        Console.WriteLine("Enter the second number:");
        string input2 = Console.ReadLine();

        try
        {
            bool isValidInput = int.TryParse(input1, out int number1) && int.TryParse(input2, out int number2);
            if (!isValidInput)
            {
                Console.WriteLine("Please enter valid integers.");
            }
            else
            {
                int result = Divide(number1, number2);
                Console.WriteLine(string.Format("The result of {0} divided by {1} is: {2}", number1, number2, result));
            }
        }
        catch (OverflowException ex)
        {
            Console.WriteLine("Error: The input number is too large or too small.");
            Console.WriteLine(string.Format("Detailed error message: {0}", ex.Message));
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("Error: Division by zero is not allowed.");
            Console.WriteLine(string.Format("Detailed error message: {0}", ex.Message));
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Error: One or both of the inputs are not valid integers.");
            Console.WriteLine(string.Format("Detailed error message: {0}", ex.Message));
        }
        catch (Exception ex)
        {
            Console.WriteLine("An unexpected error occurred.");
            Console.WriteLine(string.Format("Detailed error message: {0}", ex.Message));
        }
    }

    static int Divide(int a, int b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Attempted to divide by zero.");
        }
        return a / b;
    }
}