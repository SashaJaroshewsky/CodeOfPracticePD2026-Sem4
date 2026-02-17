namespace FileIO.WorkingWithTextFiles
{
    // Directory — це статичний клас з простору імен System.
    // Він використовується для роботи з папками (директоріями), а не з файлами
    // Тобто, якщо File — про файли, то Directory — про папки.
    internal class DirectoryIO
    {
        // Методи класу Directory:
        // Directory.CreateDirectory(string path) — створює нову папку за вказаним шляхом. Якщо папка вже існує, вона не буде перезаписана, і метод поверне обʼєкт DirectoryInfo для цієї папки.
        // Directory.Delete(string path) — видаляє папку за вказаним шляхом. Якщо папка не порожня, буде викинута помилка. Щоб видалити папку разом з усім її вмістом, можна використовувати Directory.Delete(string path, bool recursive) з параметром recursive = true.
        // Directory.Exists(string path) — перевіряє, чи існує папка за вказаним шляхом, і повертає true або false.
        // Directory.GetFiles(string path) — повертає масив рядків з повними шляхами до всіх файлів у вказаній папці.
        // Directory.GetDirectories(string path) — повертає масив рядків з повними шляхами до всіх підпапок у вказаній папці.
        // Directory.GetFileSystemEntries(string path) — повертає масив рядків з повними шляхами до всіх файлів і підпапок у вказаній папці.
        // Directory.Move(string sourceDirName, string destDirName) — переміщує папку з одного місця в інше. Якщо цільова папка існує, буде викинута помилка.
        // Directory.GetParent(string path) — повертає обʼєкт DirectoryInfo для батьківської папки вказаного шляху.
        // Directory.GetCurrentDirectory() — повертає поточний робочий каталог програми.
        // Directory.SetCurrentDirectory(string path) — встановлює поточний робочий каталог програми на вказаний шлях.
        // Directory.GetLogicalDrives() — повертає масив рядків з іменами всіх логічних дисків на компʼютері (наприклад, "C:\", "D:\", і т.д.).
        // Directory.GetCreationTime(string path) — повертає дату і час створення папки.


        

        public void ExampleDirectory()
        {
            // Створюємо папку "MyFolder" в поточному робочому каталозі
            Directory.CreateDirectory("MyFolder");
            // Перевіряємо, чи існує папка
            bool exists = Directory.Exists("MyFolder");
            Console.WriteLine($"Папка існує: {exists}");
            // Отримуємо всі файли в папці (поки що вона порожня, тому масив буде пустим)
            string[] files = Directory.GetFiles("MyFolder");
            Console.WriteLine($"Кількість файлів у папці: {files.Length}");
            // Видаляємо папку
            Directory.Delete("MyFolder");

            Directory.GetCreationTime("MyFolder");
            
        }

    }
}
