namespace ProcessesAndThreads
{
    // Task — це абстракція над ThreadPool.Це основний інструмент у сучасному C#.
    internal class TaskDefinition
    {
        public void Example()
        {
            // Запустити завдання
            Task task = Task.Run(() =>
            {
                Console.WriteLine("Task виконується!");
                Thread.Sleep(1000);
            });

            // Завдання з результатом
            Task<int> taskWithResult = Task.Run(() =>
            {
                Thread.Sleep(500);
                return 42;
            });

            task.Wait(); // Синхронне очікування (блокує потік!)
            int result = taskWithResult.Result; // Теж блокує
            Console.WriteLine($"Результат: {result}");
        }

        public async Task Example2()
        {
            Task<string> t1 = FetchDataAsync();
            Task<string> t2 = FetchDataAsync();
            Task<string> t3 = FetchDataAsync();

            // Чекаємо всі три ОДНОЧАСНО (не по черзі!)
            string[] results = await Task.WhenAll(t1, t2, t3);
            // Загальний час ~500ms, а не ~1500ms!
        }
        async Task<string> FetchDataAsync()
        {
            await Task.Delay(500); // Симулюємо HTTP запит
            return "Дані отримано!";
        }
    }
}
