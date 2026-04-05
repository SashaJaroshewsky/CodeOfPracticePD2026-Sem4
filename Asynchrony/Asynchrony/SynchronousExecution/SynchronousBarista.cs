using System.Diagnostics;

namespace Asynchrony.SynchronousExecution
{
    internal class SynchronousBarista
    {
        public void Run()
        {
            // Рахуємо час роботи програми.
            var sw = Stopwatch.StartNew();

            CoffeeMachine coffeeMachine = new CoffeeMachine();
            coffeeMachine.MakeCoffee();
            coffeeMachine.MakeCoffee();


            sw.Stop();
            Console.WriteLine( $"Пройшло часу: {sw.ElapsedMilliseconds}");
        }
    }
}
