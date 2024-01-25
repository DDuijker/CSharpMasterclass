using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Fundamentals
{
    internal class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }

        public static int GetNumberFromUser(string prompt)
        {
            int number;
            bool isNumberValid;
            do
            {
                Console.WriteLine(prompt);
                string userInput = Console.ReadLine();
                isNumberValid = int.TryParse(userInput, out number);
                if (!isNumberValid)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            } while (!isNumberValid);

            return number;
        }

        public void Start()
        {
            bool isOn = true;
            while (isOn)
            {
                int firstNumber = GetNumberFromUser("Input the first number:");
                int secondNumber = GetNumberFromUser("Input the second number:");

                //ask user for instructions
                Console.WriteLine(
                    "What do you want to do with these numbers?\n" +
                    "[A]dd\n" +
                    "[S]ubtract\n" +
                    "[M]ultiply\n" +
                    "[E]xit");

                string userInput = Console.ReadLine().ToLower();
                //handle the input 
                switch (userInput)
                {
                    case "a":
                        Console.WriteLine($"{firstNumber} + {secondNumber} =  {Add(firstNumber, secondNumber)}");
                        break;
                    case "s":
                        Console.WriteLine($"{firstNumber} - {secondNumber} =  {Subtract(firstNumber, secondNumber)}");
                        break;

                    case "m":
                        Console.WriteLine($"{firstNumber} * {secondNumber} =  {Multiply(firstNumber, secondNumber)}");
                        break;
                    case "e":
                        isOn = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                };
            }
        }
    }
}
