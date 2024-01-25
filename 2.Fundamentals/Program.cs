namespace _2.Fundamentals
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! I have made a calculator and a TODO list application.");
            while (true)
            {
                Calculator calculator = new Calculator();
                ToDoList toDoList = new ToDoList();
                Console.WriteLine(
                    "\nPress 'C' to start the calculator:" +
                    "\nPress 'T' to start the TODO list application:" +
                    "\nType 'exit' to exit the application");
                string userInput = Console.ReadLine().ToLower();

                if (userInput == "exit")
                {
                    break;
                }
                else if (userInput == "c")
                {
                    calculator.Start();
                }
                else if (userInput == "t")
                {
                    ToDoList.Start();
                }         
                else
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }
            Console.ReadKey();
            }
        }
    }
}