using System.Diagnostics;

namespace ProcessesAndThreads
{
    // Процес(Process) — це програма, яка виконується. Коли запускається.exe файл, операційна система створює процес.

    // Аналогія:
    // Уявіть ресторан.
    // Процес — це весь ресторан цілком: приміщення, кухня, персонал, меню.
    // Кожен ресторан живе в своєму "просторі" — один ресторан не може залізти на кухню іншого.

    // Кожен процес має:
    // - Власну пам'ять: кожен процес має свій власний простір пам'яті, який не може бути безпосередньо доступний іншим процесам. Це забезпечує безпеку та стабільність системи.
    // - Власні ресурси: процеси мають свої власні ресурси, такі як файли, мережеві з'єднання та пристрої. Вони не можуть безпосередньо використовувати ресурси інших процесів.
    // - Власні потоки: процес може містити один або кілька потоків виконання, які працюють паралельно в межах цього процесу. Потоки в одному процесі можуть спільно використовувати ресурси та пам'ять, але не можуть безпосередньо взаємодіяти з потоками інших процесів.

    internal class ProcessDefinition
    {
        // Метод для демонстрації інформації про поточний процес
        public void ShowProcessInfo()
        {
            Process currentProcess = Process.GetCurrentProcess();
            Console.WriteLine($"Process Name: {currentProcess.ProcessName}");
            Console.WriteLine($"Process ID: {currentProcess.Id}");
            Console.WriteLine($"Memory Usage: {currentProcess.WorkingSet64} bytes");
        }

        // Запуск нового процесу (наприклад, блокнота)
        public void StartNewProcess()
        {
            //Process process = Process.Start("notepad.exe");
            Process process = new Process();
            process.StartInfo.FileName = "notepad.exe";
            // StartInfo - це властивість, яка дозволяє налаштувати параметри запуску процесу, такі як ім'я файлу, аргументи командного рядка, робоча директорія та інші.
            // Вона є об'єктом типу ProcessStartInfo, який містить всі необхідні налаштування для запуску процесу.
            process.StartInfo.Arguments = "example.txt"; // Передаємо аргумент для відкриття конкретного файлу в блокноті
            process.Start();
            Console.WriteLine($"Started new process with ID: {process.Id}");

            process.WaitForExit(); // Чекаємо, поки процес завершиться
            Console.WriteLine("Notepad process has exited.");
        }
    }
}
