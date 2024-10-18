
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the first number:");
        string input1 = Console.ReadLine();

        Console.WriteLine("Enter the second number:");
        string input2 = Console.ReadLine();

        // No try-catch block, so any exception will terminate the program
        bool isValidInput = int.TryParse(input1, out int number1) && int.TryParse(input2, out int number2);
        if (!isValidInput)
        {
            Console.WriteLine("Please enter valid integers.");
        }
        else
        {
            // This will throw DivideByZeroException if b == 0 or if any other error occurs
            int result = Divide(number1, number2);
            Console.WriteLine(string.Format("The result of {0} divided by {1} is: {2}", number1, number2, result));
        }
    }

    static int Divide(int a, int b)
    {
        return a / b;  // This line will throw DivideByZeroException if b is 0
    }
}