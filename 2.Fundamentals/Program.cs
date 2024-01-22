namespace _2.Fundamentals
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            Console.WriteLine("Hello! I have made a calculator. Press 'S' to start: ");
            if (Console.ReadLine().ToLower() == "s")
            {
                calculator.Start();
            }
            Console.ReadKey();
        }
    }
}