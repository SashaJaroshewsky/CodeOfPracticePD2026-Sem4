using Asynchrony.SynchronousExecution;
using Asynchrony.AsynchronousExecution;

namespace Asynchrony
{
    
    internal class Program
    {
        // При запуску .exe операційна система створює процес для виконання програми.
        // Усередині цього процесу .NET Runtime (CLR) створює головний потік (Main Thread),
        // у якому запускається метод Main.
        // Код у цьому потоці виконується послідовно — кожна інструкція виконується після попередньої.

        // Нагадую)
        // Main - це точка входу в програму, де починається виконання коду.
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Встановлюємо кодування для консолі, щоб коректно відображати українські символи.
            Console.WriteLine("Друга стрічка)");
            Console.WriteLine("Один потік виконує код послідовно");

            //Console.WriteLine($"Головний потік: {Thread.CurrentThread.ManagedThreadId}");

            SynchronousBarista synchronousBarista = new SynchronousBarista();
            synchronousBarista.Run(); // Викликаємо метод Run, який виконує код послідовно, блокуючи потік, доки не завершиться виконання.
            

            AsynchronousBarista asynchronousBarista = new AsynchronousBarista();
            _ = asynchronousBarista.Run(); // Викликаємо метод Run, який виконує код асинхронно, дозволяючи потоку продовжувати виконання інших інструкцій, не чекаючи завершення.
            // _ - це discard, який використовується для ігнорування результату виконання методу Run, оскільки він повертає Task, який ми не хочемо використовувати в цьому випадку.
            Console.WriteLine("Кінець");
           // Console.ReadKey(); // Чекаємо на натискання клавіші, щоб програма не закрилась одразу після виконання коду.
        }
    }



}
