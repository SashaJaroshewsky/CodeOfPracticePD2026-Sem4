using System.IO;

namespace FileIO.WorkingWithTextFiles
{
    // StreamReader — для читання тексту з потока (він автоматично перетворює байти в текст).

    // Що він робить під капотом?

    // StreamReader бере байти з Stream, використовує таблицю кодування (наприклад, UTF-8) і збирає з них символи.
    // Він має свій внутрішній буфер (зазвичай 4 КБ). Він читає з диска великий "шматок",
    // кладе його в пам'ять і видає тобі по одному символу або рядку, поки буфер не спорожніє. Потім він іде за новою порцією.

    // Покрокова робота StreamReader:
    // 1. Ствроює потік для читання тексту, вказуючи шлях до файлу або базовий потік (наприклад, FileStream).
    // 2. Створює внутрішній буфер для зберігання байтів, які він читає з базового потока (наприклад, FileStream).
    // 3. Коли ви викликаєте методи Read або ReadLine, StreamReader перевіряє, чи є в його буфері достатньо байтів для перетворення в символи.
    //    Якщо ні, він читає більше байтів з базового потока (наприклад, FileStream) і оновлює свій буфер.
    // 4. Потім він використовує вибране кодування (за замовчуванням UTF-8) для перетворення байтів у символи і повертає їх вам.
    // 5. Після закриття StreamReader, він автоматично закриє свій базовий потік (якщо він його створив), що забезпечує правильне звільнення ресурсів.

    // Використання StreamReader робить роботу з текстовими файлами набагато зручнішою, оскільки вам не потрібно турбуватися про перетворення байтів у текст та керування буфером — все це робить за вас StreamReader.
    internal class StreamReaderIO
    {
        // Використовуємо StreamReader для читання тексту з файлу
        public void CreateFileStreamWithStreamReader()
        {
            string filePath = "example_with_StreamWriter.txt";
            using (StreamReader sr = new StreamReader(filePath))
            {
                string content = sr.ReadToEnd();
                Console.WriteLine(content);
            }
            // Після закриття using, StreamReader автоматично закриє свій внутрішній FileStream, що забезпечує правильне звільнення ресурсів.
            // Це потрібно розуміти, щоб уникнути проблем з блокуванням файлів або витоками ресурсів.
        }

        // Основні конструктори StreamReader:
        // StreamReader(string path) — створює StreamReader, який читає з файлу за вказаним шляхом. Якщо файл не існує, буде викинута помилка.
        // StreamReader(Stream stream) — створює StreamReader, який читає з базового потока (наприклад, FileStream). Ви повинні забезпечити, що цей потік підтримує читання.
        // StreamReader(string path, Encoding encoding) — створює StreamReader з можливістю вказати кодування для перетворення байтів у текст.
        // StreamReader(Stream stream, Encoding encoding) — створює StreamReader, який читає з базового потока з вказаним кодуванням.

        // Приклад використання конструктора StreamReader з різними параметрами:
        public void ConstructorsStreamReader()
        {
            // Читаємо текст з файлу за вказаним шляхом
            using (StreamReader sr = new StreamReader("file1.txt"))
            {
                string content = sr.ReadToEnd();
                Console.WriteLine(content);
            }
            // Читаємо текст з базового потока (наприклад, FileStream)
            using (FileStream fs = new FileStream("file1.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string content = sr.ReadToEnd();
                    Console.WriteLine(content);
                }
            }
            // Читаємо текст з файлу з вказаним кодуванням (наприклад, UTF-8)
            using (StreamReader sr = new StreamReader("file2.txt", System.Text.Encoding.UTF8))
            {
                string content = sr.ReadToEnd();
                Console.WriteLine(content);
            }
            // Читаємо текст з базового потока з вказаним кодуванням
            using (FileStream fs = new FileStream("file3.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs, System.Text.Encoding.UTF8))
                {
                    string content = sr.ReadToEnd();
                    Console.WriteLine(content);
                }
            }
        }

        // Основні методи читання:
        // Read() — читає один символ і повертає його як int (або -1, якщо досягнуто кінця потока).
        // ReadLine() — читає рядок тексту до символу нового рядка (\n) і повертає його як string (або null, якщо досягнуто конца потока).
        // ReadToEnd() — читає весь залишок потока і повертає його як string.
        // Read(char[] buffer, int index, int count) — читає до count символів в масив buffer, починаючи з позиції index, і повертає кількість фактично прочитаних символів.
        // Peek() — повертає наступний символ без його зчитування (або -1, якщо досягнуто конца потока).
        // ReadBlock(char[] buffer, int index, int count) — читає до count символів в масив buffer, починаючи з позиции index, і повертає кількість фактично прочитаних символів. Це блокуюча версія Read.
        // DiscardBufferedData() — очищає внутрішній буфер StreamReader. Це може бути корисно, якщо ви хочете змінити позицію в базовому потоці і хочете, щоб StreamReader "підхопив" ці зміни.
        // Close() — закриває StreamReader і його базовий потік, звільняючи ресурси. Викликається автоматично при використанні конструкції using.
        // Dispose() — викликає Close() і звільняє ресурси. Викликається автоматично при використанні конструкції using.

        // Корисні властивості:
        // EndOfStream — булеве значення, яке показує, чи досягнуто кінця потоку.
        // CurrentEncoding — повертає кодування, яке використовується для перетворення байтів у текст.
        // BaseStream — повертає базовий потік, з якого StreamReader читає дані (наприклад, FileStream).

        // Приклад читання великого файлу по рядках:
        public void ReadLargeFileLineByLine()
        {
            try
            {
                string path = "largefile.txt";
                if (File.Exists(path))
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"An I/O error occurred: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
