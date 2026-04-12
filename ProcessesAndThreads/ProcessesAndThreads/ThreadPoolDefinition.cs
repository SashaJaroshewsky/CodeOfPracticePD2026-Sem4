namespace ProcessesAndThreads
{
    // Створення потоку — дорога операція (час + ~1MB пам'яті). ThreadPool — це набір вже готових потоків, які чекають роботи.

    // Аналогія:
    // Замість найму нових офіціантів для кожного столика — є команда офіціантів у зоні відпочинку.
    // Нове замовлення? Вільний офіціант іде працювати. Закінчив — повертається відпочивати.
    internal class ThreadPoolDefinition
    {
        // Відправити роботу в пул
        public void Example()
        {
            ThreadPool.QueueUserWorkItem(state =>
            {
                Console.WriteLine($"Пул, потік: {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(500);
                Console.WriteLine("Пул: робота виконана");
            });

            // Дізнатись розмір пулу
            ThreadPool.GetMaxThreads(out int workerThreads, out int ioThreads);
            Console.WriteLine($"Max worker threads: {workerThreads}");
            Console.WriteLine($"ioThreads: {ioThreads}");
        }
    }
}
