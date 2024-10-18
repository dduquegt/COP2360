using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the first number:");
        string input1 = Console.ReadLine();

        Console.WriteLine("Enter the second number:");
        string input2 = Console.ReadLine();

        string logFilePath = "error_log.txt"; // Log file for detailed error logging

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
                Console.WriteLine($"The result of {number1} divided by {number2} is: {result}");
            }
        }
        catch (OverflowException ex)
        {
            string errorMessage = "Error: The input number is too large or too small for an integer.";
            LogError(logFilePath, errorMessage, ex);
            Console.WriteLine($"{errorMessage} Please see the log for more details.");
        }
        catch (DivideByZeroException ex)
        {
            string errorMessage = "Error: Division by zero is not allowed.";
            LogError(logFilePath, errorMessage, ex);
            Console.WriteLine($"{errorMessage} Please see the log for more details.");
        }
        catch (FormatException ex)
        {
            string errorMessage = "Error: One or both of the inputs are not valid integers.";
            LogError(logFilePath, errorMessage, ex);
            Console.WriteLine($"{errorMessage} Please see the log for more details.");
        }
        catch (Exception ex)
        {
            string errorMessage = "An unexpected error occurred.";
            LogError(logFilePath, errorMessage, ex);
            Console.WriteLine($"{errorMessage} Please see the log for more details.");
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

    
    static void LogError(string filePath, string message, Exception ex)
    {
        string logMessage = $"[{DateTime.Now}] {message}\nException Message: {ex.Message}\nStack Trace: {ex.StackTrace}\n";
        File.AppendAllText(filePath, logMessage); 
    }
}