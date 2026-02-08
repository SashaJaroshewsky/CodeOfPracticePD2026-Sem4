

using System.Text;

namespace Events
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            ExampleBad example1Bad = new ExampleBad();
            example1Bad.Example();
            Console.ReadLine();
        }
    }
}
