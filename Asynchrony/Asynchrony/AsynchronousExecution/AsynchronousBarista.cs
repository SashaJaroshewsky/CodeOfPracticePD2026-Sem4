using System.Diagnostics;

namespace Asynchrony.AsynchronousExecution
{
    internal class AsynchronousBarista
    {
        public async Task Run()
        {
            var sw = Stopwatch.StartNew(); // Можливо вивчимо це пізніше, але це клас для вимірювання часу виконання певного коду. 

            CoffeeMachine coffeeMachine = new CoffeeMachine();

            Task task = coffeeMachine.MakeCoffee(1); //Виконується асинхронно тому що ми не чекаємо на результат, а запускаємо іншу роботу

            while (!task.IsCompleted)
            {
                Console.WriteLine("Витираю поверхню...");
            } // Поки не завершиться приготування кави, ми можемо виконувати інші завдання, наприклад, витирати поверхню.

            await task; // Чекаємо на завершення приготування кави, якщо вона ще не готова. Якщо вона вже готова, то цей рядок виконається миттєво.

            sw.Stop(); // Зупиняємо вимірювання часу.
            Console.WriteLine($"Пройшло часу: {sw.ElapsedMilliseconds}");
        }
    }
}
