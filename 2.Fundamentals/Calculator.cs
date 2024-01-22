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

        public void Start()
        {
            Console.WriteLine("Hello!\nInput the first number:");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Input the second number:");
            int secondNumber = int.Parse(Console.ReadLine());
            //ask user for instructions
            Console.WriteLine(
                "What do you want to do with these numbers?\n" +
                "[A]dd\n" +
                "[S]ubtract\n" +
                "[M]ultiply");

            string userInput = Console.ReadLine().ToLower();
            //handle the input 
            if (userInput == "a")
            {
                Console.WriteLine($"{firstNumber} + {secondNumber} =  {Add(firstNumber, secondNumber)}");
            }
            else if (userInput == "s")
            {
                Console.WriteLine($"{firstNumber} - {secondNumber} =  {Subtract(firstNumber, secondNumber)}");
            }
            else if (userInput == "m")
            {
                Console.WriteLine($"{firstNumber} * {secondNumber} =  {Multiply(firstNumber, secondNumber)}");
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
        }
    }
}
