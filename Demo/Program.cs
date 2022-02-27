using System;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("User, please enter your name:");
            string name = Console.ReadLine();

            Console.WriteLine("User, please enter your age:");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine($"User name: {name} and he/she is {age} years old.");
        }
    }
}
