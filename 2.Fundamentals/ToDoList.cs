using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * This application is a simple TODO manager. Each todo is only a simple description of a thing to be done. 
 * Each description must be unique.
 * TODO's can be addedm removed or listed.
 */
namespace _2.Fundamentals
{
    internal class ToDoList
    {
        // initialize variables
        public static void ShowOptions()
        {
            Console.WriteLine("\nWhat do you want to do?" +
                "\n[S]ee all todo's" +
                "\n[A]dd a todo" +
                "\n[R]emove a todo" +
                "\n[E]xit");
        }

        public static void SeeAllToDo(List<string> todos)
        {
            if (todos.Count > 0)
            {
                Console.WriteLine("\n");
                for (int i = 0; i < todos.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {todos[i]}");
                }
            }
            else
            {
                Console.WriteLine("No TODO's have been added yet.");
            }
        }

        public static void Add(List<string> todos)
        {
            Console.WriteLine("Enter the TODO description:");
            string userInput = Console.ReadLine();
            bool continueAsking = true;

            while (continueAsking)
            {
                // check if input is empty
                if (userInput == null || userInput == "" || userInput == " ")
                {
                    Console.WriteLine("The description cannot be empty.");
                }
                else if (todos.Contains(userInput))
                {
                    Console.WriteLine("Description must be unique");
                }
                else
                {
                    todos.Add(userInput);
                    Console.WriteLine($"TODO succesfully added: {userInput}");
                    continueAsking = false;
                }
            }
        }

        public static void RemoveItem(List<string> todos)
        {
            bool continueAsking = true;
            while (continueAsking)
            {
                Console.WriteLine("Select the index of the TODO you want to remove");
                SeeAllToDo(todos);
                Console.WriteLine("");
                string userInput = Console.ReadLine();

                if ( userInput == "" || userInput == null)
                {
                    Console.WriteLine("Selected index cannot be empty");
                    continue;
                }

                bool isValidInt = int.TryParse(userInput, out int index);
                index -= 1;
                if (isValidInt)
                {
                    // check if int is a valid index
                    bool isValidIndex = index >= 0 && index < todos.Count;
                    if (isValidIndex)
                    {
                        Console.WriteLine($"TODO removed: {todos[index]}");
                        todos.Remove(todos[index]);
                        continueAsking=false;
                    }
                    else
                    {
                        Console.WriteLine("The given index is not valid.");
                    }

                }
            }
        }

        public static void Start()
        {
            List<char> validChoices = new List<char>() { 's', 'a', 'r', 'e' };
            List<string> todoList = new List<string>();
            bool isOn = true;

            while (isOn)
            {
                // show the options
                ShowOptions();

                // request input
                string userChoice = Console.ReadLine().ToLower();

                // check if choice is a character
                bool isChar = char.TryParse(userChoice, out char parsedChoice);
                if (isChar)
                {
                    // check if character is in the list of valid options
                    if (validChoices.Contains(parsedChoice))
                    {
                        switch (parsedChoice)
                        {
                            case 's':
                                SeeAllToDo(todoList);
                                continue;
                            case 'a':
                                Add(todoList);
                                continue;
                            case 'r':
                                RemoveItem(todoList);
                                continue;
                            case 'e':
                                isOn = false;
                                Environment.Exit(0);
                                break;
                            default:
                                continue;
                        }
                        SeeAllToDo(todoList); break;
                    }
                    else
                    {
                        Console.WriteLine("Not a valid option");
                        continue;
                    }
                }
            }

        }
    }
}
