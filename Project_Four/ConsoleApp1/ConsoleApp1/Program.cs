
using System.Runtime.InteropServices;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("First number: ");
            int firstNumber = int.Parse(Console.ReadLine());

            Console.Write("Second number: ");
            int secondNumber = int.Parse(Console.ReadLine());

            int result = Multiple(firstNumber, secondNumber);

            Console.WriteLine("Result: " + result);
            Console.ReadLine();
        }

        [DllImport("Dll_Project.dll", CallingConvention = CallingConvention.Cdecl)] // clear garbage -> c#, not dll
        static extern int Multiple(int a, int b);
    }
}
