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
                return;
            }
        }

        public static bool IsDescriptionValid(string description, List<string> todos)
        {
            // check if input is empty
            if (description == null || description == "" || description == " ")
            {
                Console.WriteLine("The description cannot be empty.");
                return false;
            }
            else if (todos.Contains(description))
            {
                Console.WriteLine("Description must be unique");
                return false;
            }
            return true;

        }

        public static void Add(List<string> todos)
        {
            Console.WriteLine("Enter the TODO description:");
            string userInput = Console.ReadLine();
            bool continueAsking = true;

            while (continueAsking)
            {
                if (IsDescriptionValid(userInput, todos))
                {
                    todos.Add(userInput);
                    Console.WriteLine($"TODO succesfully added: {userInput}");
                    continueAsking = false;
                }
            }
        }
        public static bool IsValidIndex(string userInput, out int index, List<string> todos)
        {
            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine("Selected index cannot be empty. Please enter a valid number.");
                index = -1;
                return false;
            }

            if (!int.TryParse(userInput, out index))
            {
                Console.WriteLine("Given index is not a valid integer. Please enter a number.");
                return false;
            }

            index -= 1; // Adjust index to match zero-based indexing

            if (index < 0 || index >= todos.Count)
            {
                Console.WriteLine("The given index is not valid. Please enter a valid number.");
                return false;
            }

            return true;
        }

        public static void RemoveItem(List<string> todos)
        {
            bool stop = false;
            while (!stop)
            {
                Console.WriteLine("Select the index of the TODO you want to remove");
                SeeAllToDo(todos);

                if (todos.Count > 0)
                {
                    Console.WriteLine("");
                    string userInput = Console.ReadLine();

                    if (IsValidIndex(userInput, out int index, todos))
                    {
                        Console.WriteLine($"TODO removed: {todos[index]}");
                        todos.RemoveAt(index);
                        stop = true;
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
