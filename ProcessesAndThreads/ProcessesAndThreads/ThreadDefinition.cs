namespace ProcessesAndThreads
{
    // Потік(Thread) — це одиниця виконання в межах процесу. Коли процес запускається, він створює принаймні один потік, який виконує код програми.
    // Потоки в одному процесі можуть спільно використовувати ресурси та пам'ять, але не можуть безпосередньо взаємодіяти з потоками інших процесів.

    // Аналогія:
    // Якщо процес — це ресторан, то потоки — це офіціанти.
    // Один офіціант (головний потік) приймає замовлення. Але якщо офіціант тільки один — поки він несе страву, нікого немає щоб прийняти нове замовлення.
    // Тому наймають більше офіціантів (додаткові потоки) — вони працюють одночасно, діляться кухнею (пам'яттю), але кожен має свій блокнот (stack).

    
    internal class ThreadDefinition
    {

        // Метод для демонстрації інформації про поточний потік
        public void ShowThreadInfo()
        {
            Thread currentThread = Thread.CurrentThread;
            Console.WriteLine($"Thread Name: {currentThread.Name}");
            Console.WriteLine($"Thread ID: {currentThread.ManagedThreadId}");
            Console.WriteLine($"Is Background Thread: {currentThread.IsBackground}");
        }

        // Запуск нового потоку
        public void StartNewThread()
        {
            // Спосіб 1: Використання делегата ThreadStart
            Thread thread1 = new Thread(new ThreadStart(WorkerMethod));
            thread1.Name = "WorkerThread1";
            thread1.Start();

            // Спосіб 2: Використання лямбда-виразу
            Thread thread2 = new Thread(() =>
            {
                Console.WriteLine($"Потік {Thread.CurrentThread.ManagedThreadId} працює (лямбда)!");
                Thread.Sleep(2000); // Імітуємо роботу
                Console.WriteLine("Робота завершена (лямбда)!");
            });

        }

        private void WorkerMethod()
        {
            Console.WriteLine($"Потік {Thread.CurrentThread.ManagedThreadId} працює!");
            Thread.Sleep(2000); // Імітуємо роботу
            Console.WriteLine("Робота завершена!");
        }

        // Методи та властивості потока

        // Методи:
        // - Start(): запускає потік.
        // - Sleep(int milliseconds): призупиняє виконання потока на вказану кількість мілісекунд.
        // - Join(): чекає, поки потік завершиться.

        // Властивості:
        // - Name: ім'я потока (можна встановити для зручності).    
        // - IsBackground: визначає, чи є потік фоновим (background) чи переднім планом (foreground). За замовчуванням потоки є передніми.
        // - ManagedThreadId: унікальний ідентифікатор потока, який призначається CLR.
        // - ThreadState: поточний стан потока (наприклад, Running, Stopped, WaitSleepJoin тощо).
        // - Priority: пріоритет потока, який може впливати на планування виконання потока операційною системою.
        // - IsAlive: визначає, чи потік все ще виконується.
        // - IsThreadPoolThread: визначає, чи потік є потоком з ThreadPool.
    }
}
