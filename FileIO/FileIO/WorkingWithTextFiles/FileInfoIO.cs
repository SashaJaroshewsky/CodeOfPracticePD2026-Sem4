namespace FileIO.WorkingWithTextFiles
{
    // FileInfo - це клас з простору імен: System.IO. Він представляє конкретний файл як обʼєкт.

    // Якщо File — це набір статичних методів,
    // то FileInfo — це ООП-представлення файлу
    internal class FileInfoIO
    {
        // Приклад файлу, з яким ми будемо працювати
        public void FileInfoExample()
        {
            // Створюємо обʼєкт FileInfo для файлу "example.txt"
            FileInfo fileInfo = new FileInfo("example.txt");
            // FileInfo може представляти не лише текстовий файл, а й будь-який інший тип файлу (зображення, аудіо, відео і т.д.)
            FileInfo imageInfo = new FileInfo("image.png");
            // І не важливо, чи існує файл на диску — FileInfo все одно створиться і буде представляти цей шлях. Але якщо ви спробуєте отримати інформацію про файл, який не існує, ви отримаєте помилку.
            // Тепер fileInfo — це об’єкт, з яким можна працювати.

        }

        // Властивості:

        // FileInfo.Name — повертає імʼя файлу з розширенням (наприклад, "example.txt").
        // FileInfo.FullName — повертає повний шлях до файлу (наприклад, "C:\Users\Username\Documents\example.txt").
        // FileInfo.Extension — повертає розширення файлу (наприклад, ".txt").
        // FileInfo.Length — повертає розмір файлу в байтах.
        // FileInfo.CreationTime — повертає дату і час створення файлу.
        // FileInfo.LastAccessTime — повертає дату і час останнього доступу до файлу.
        // FileInfo.LastWriteTime — повертає дату і час останньої модифікації файлу.
        // FileInfo.Exists — булева властивість, яка показує, чи існує файл на диску.
        // FileInfo.DirectoryName — повертає імʼя каталогу, в якому знаходиться файл.
        // FileInfo.IsReadOnly — булева властивість, яка показує, чи є файл доступним лише для читання.
        // FileInfo.Attributes — повертає атрибути файлу (наприклад, ReadOnly, Hidden, System і т.д.).
        // FileInfo.Directory — повертає обʼєкт DirectoryInfo, який представляє каталог, в якому знаходиться файл.

        // За допомогою цих властивостей ви можете отримати багато корисної інформації про файл, не відкриваючи його для читання або запису. Це особливо корисно для перевірки існування файлу, отримання його розміру або визначення його типу за розширенням.

        // Методи:
        // FileInfo.Create() — створює новий файл і повертає FileStream для запису. Якщо файл існує, він буде перезаписаний.
        // FileInfo.Delete() — видаляє файл. Якщо файл не існує, буде викинута помилка.
        // FileInfo.MoveTo(string destFileName) — переміщує файл в нове місце з вказаним шляхом. Якщо цільовий файл існує, буде викинута помилка.   
        // FileInfo.CopyTo(string destFileName) — копіює файл в нове місце з вказаним шляхом. Якщо цільовий файл існує, буде викинута помилка.
        // FileInfo.Open(FileMode mode, FileAccess access) — відкриває файл для читання або запису з вказаними режимом і правами доступу. Повертає FileStream для роботи з файлом.
        // FileInfo.OpenRead() — відкриває файл для читання і повертає FileStream.
        // FileInfo.OpenWrite() — відкриває файл для запису і повертає FileStream.
        // FileInfo.AppendText() — відкриває файл для додавання тексту і повертає StreamWriter.
        // FileInfo.CreateText() — створює новий текстовий файл і повертає StreamWriter для запису. Якщо файл існує, він буде перезаписаний.

        // Важливий момент
        // FileInfo не створює файл автоматично.
        public void FileInfoExample2()
        {
            var file = new FileInfo("new.txt");
            // Якщо ми спробуємо отримати інформацію про цей файл, який ще не існує, ми отримаємо помилку
            file.Create(); // Створює файл "new.txt" на диску
            // Саме після цього буде створено файл, і ми зможемо отримати його властивості;
        }

        // Важливо для розуміння
        // Потрібно загортати в using або вручну закривати потоки, які повертають методи FileInfo (наприклад, Create(), OpenRead(), OpenWrite() і т.д.), щоб уникнути проблем з блокуванням файлів або витоками ресурсів.
        // Також потрібно загортати в try-catch блоки, щоб обробляти можливі помилки, які можуть виникнути при роботі з файлами (наприклад, файл не існує, немає прав доступу і т.д.).

        // Наприклад:
        public void FileInfoExample3()
        {
            var file = new FileInfo("new.txt");
            try
            {
                // using var stream = file.Create(); // Створює файл "new.txt" на диску і повертає FileStream для 
                // Коли ми створюємо потік через Create(), він доступний лише для запису
                // Створювати файл через Create() і подібні методи потрібен тільки якщо хочете контролювати потік на рівні FileStream.
                // Для простого запису тексту достатньо StreamWriter(fileName) або File.WriteAllText().

                using (var writer = new StreamWriter(file.Name))
                {
                    writer.WriteLine("Hello, World!");
                    writer.WriteLine(file.Name);
                    writer.WriteLine(file.FullName);
                    writer.WriteLine(file.Extension);
                    writer.WriteLine(file.Length);
                    writer.WriteLine(file.CreationTime);
                    writer.WriteLine(file.LastWriteTime);
                    writer.WriteLine(file.Exists);
                    writer.WriteLine(file.DirectoryName);
                    writer.WriteLine(file.IsReadOnly);
                }
                // File.WriteAllText(file.Name, "Hello, World!"); // Це більш простий спосіб запису тексту в файл без необхідності контролювати потік.

                // Відкриваємо файл для читання
                using var stream1 = file.OpenRead();

                // Читаємо з файлу
                string content;
                using var reader = new StreamReader(stream1);
                content =  reader.ReadToEnd();
                Console.WriteLine(content);


            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Файл не знайдено: {ex.Message}");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Недостатньо прав для доступу до файла: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Помилка вводу/виводу: {ex.Message}");
            }
        }
    }
}
