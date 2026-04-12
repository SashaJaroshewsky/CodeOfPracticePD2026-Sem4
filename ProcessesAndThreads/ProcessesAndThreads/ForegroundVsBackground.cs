using System.Diagnostics;

namespace ProcessesAndThreads
{
    // У C# існує два типи потоків: передній план (foreground) і фоновий (background).

    //                                     Foreground      Background
    // Зупиняє завершення програми?          Так               Ні
    // За замовчуванням                   new Thread()  ThreadPool, Task
    internal class ForegroundVsBackground
    {
        // Передні потоки (Foreground Threads) — це потоки, які зупиняють завершення програми.
        // Якщо в програмі є хоча б один передній потік, то програма не може завершитися, поки цей потік не завершиться.

        // Приклад з використанням переднього потока:
        public void ForegroundThreadExample()
        {
            Thread foregroundThread = new Thread(() =>
            {
                Console.WriteLine("Це передній потік. Він зупиняє завершення програми.");
                Thread.Sleep(5000); // Імітуємо роботу
                Console.WriteLine("Передній потік завершився.");
            });
            foregroundThread.IsBackground = false; // за замовчуванням
            foregroundThread.Start();
        }

        // Фонові потоки (Background Threads) — це потоки, які не зупиняють завершення програми.
        // Якщо всі потоки в програмі є фоновими, то програма може завершитися, навіть якщо ці потоки ще працюють.

        // Приклад з використанням фонового потока:
        public void BackgroundThreadExample()
        {
            Thread backgroundThread = new Thread(() =>
            {
                Console.WriteLine("Це фоновий потік. Він не зупиняє завершення программы.");
                Thread.Sleep(5000); // Імітуємо роботу
                Console.WriteLine("Фоновий потік завершився.");
            });
            backgroundThread.IsBackground = true; // Встановлюємо як фоновий
            backgroundThread.Start();
        }

        // Коли ми використовували Task або ThreadPool, вони автоматично створюють фонові потоки.
        // Приклад з використанням Task:
        public void TaskExample()
        {
            Console.WriteLine("Потік виконання до створення Task.");
            Console.WriteLine($"Потік {Thread.CurrentThread.ManagedThreadId} працює!");

            Task.Run(() =>
            {
                Console.WriteLine("Це фоновий потік, створений за допомогою Task.");
                Console.WriteLine($"Потік {Thread.CurrentThread.ManagedThreadId} працює!");
                Thread.Sleep(5000); // Імітуємо роботу
                Console.WriteLine("Фоновий потік (Task) завершився.");
            });
            // Task може виконуватися на потоці з ThreadPool або навіть синхронно, якщо це можливо. Але за замовчуванням Task.Run створює фоновий потік.
        }

    }
}
