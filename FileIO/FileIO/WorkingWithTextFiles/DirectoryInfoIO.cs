using System.IO;

namespace FileIO.WorkingWithTextFiles
{
    // DirectoryInfo — це обʼєктна обгортка над папкою, аналог FileInfo для файлів.
    // Простіше кажучи
    // Directory — статичний клас (швидкі дії з папками
    // DirectoryInfo — клас-об’єкт, який представляє конкретну папку.
    internal class DirectoryInfoIO
    {
        // Приклад директорії з якою працюватимемо
        public void Example()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo("MyFolder");
            // Тепер directoryInfo — це об’єкт папки, з яким можна працювати.
            directoryInfo.Create(); // Створює папку "MyFolder";
            // Тепер вона є на диску;
        }

        // Методи класу DirectoryInfo:
        // DirectoryInfo.Create() — створює папку, яку представляє цей обʼєкт. Якщо папка вже існує, буде викинута помилка.
        // DirectoryInfo.Delete() — видаляє папку, яку представляє цей обʼєкт. Якщо папка не порожня, буде викинута помилка. Щоб видалити папку разом з усім її вмістом, можна використовувати DirectoryInfo.Delete(bool recursive) з параметром recursive = true.
        // DirectoryInfo.Exists — властивість, яка повертає true, якщо папка, яку представляє цей обʼєкт, існує на диску, і false в іншому випадку.
        // DirectoryInfo.GetFiles() — повертає масив FileInfo для всіх файлів у папці, яку представляє цей обʼєкт.
        // DirectoryInfo.GetDirectories() — повертає масив DirectoryInfo для всіх підпапок у папці, яку представляє цей обʼєкт.
        // DirectoryInfo.GetFileSystemInfos() — повертає масив FileSystemInfo для всіх файлів і підпапок у папці, яку представляє цей обʼєкт.
        // DirectoryInfo.MoveTo(string destDirName) — переміщує папку, яку представляє цей обʼєкт, в інше місце. Якщо цільова папка існує, буде викинута помилка.
        // DirectoryInfo.CreateSubdirectory(string path) — створює підпапку з вказаним імʼям всередині папки, яку представляє цей обʼєкт, і повертає DirectoryInfo для цієї підпапки. Якщо підпапка вже існує, буде викинута помилка. 

        // Властивості класу DirectoryInfo:
        // DirectoryInfo.Name — властивість, яка повертає імʼя папки без шляху (наприклад, "MyFolder").
        // DirectoryInfo.FullName — властивість, яка повертає повний шлях до папки (наприклад, "C:\Users\Username\Documents\MyFolder").
        // DirectoryInfo.Parent — властивість, яка повертає DirectoryInfo для батьківської папки цієї папки.
        // DirectoryInfo.Root — властивість, яка повертає DirectoryInfo для кореневого каталогу диска цієї папки.
        // DirectoryInfo.CreationTime — властивість для отримання або встановлення дати і часу створення папки.
        // DirectoryInfo.LastAccessTime — властивість для отримання або встановлення дати і часу останнього доступу до папки.
        // DirectoryInfo.LastWriteTime — властивість для отримання або встановлення дати і часу останньої зміни папки.

        public void Example2()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo("Example2");
            // Створюємо папку, якщо її ще немає
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }
            // Створюємо кілька файлів у папці
            for (int i = 1; i <= directoryInfo.Name.Length; i++)
            {
                string filePath = Path.Combine(directoryInfo.FullName, $"file{i}.txt");
                File.WriteAllText(filePath, $"Це файл {i}");
            }
            // Отримуємо всі файли в папці
            FileInfo[] files = directoryInfo.GetFiles();
            Console.WriteLine($"Кількість файлів у папці: {files.Length}");
            // Видаляємо папку разом з усім її вмістом
            directoryInfo.Delete(true);
        }
    }
}
