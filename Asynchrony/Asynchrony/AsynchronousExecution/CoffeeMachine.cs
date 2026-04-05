
namespace Asynchrony.AsynchronousExecution
{
    internal class CoffeeMachine
    {
        public async Task MakeCoffee(int a)
        {
            Console.WriteLine($"Кавомашина готує каву {a}...");
           
            // Імітуємо час приготування кави
            await Task.Delay(2000); // Затримка 2 секунди // Не блокує потік, а дозволяє виконувати інші інструкції під час приготування кави
            Console.WriteLine($"Кавомашина закінчила готувати каву! {a}");
        }
    }
}
