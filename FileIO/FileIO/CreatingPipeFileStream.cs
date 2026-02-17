using System.IO;

namespace FileIO
{
    //FileStream — це найнижчий рівень роботи з файлом. Він бачить файл як набір байтів. Щоб його відкрити, нам потрібно вказати три речі:
    // 1. Шлях до файлу (string path)
    // 2. Режим відкриття (FileMode mode) — як ми хочемо працювати з файлом (читати, писати, створювати і т.д.)
    // 3. Права доступу (FileAccess access) — які операції ми хочемо виконувати (читання, запис, або і те, і інше).
   
    internal class CreatingPipeFileStream
    {
        FileStream _fileStream;

        // Приклад створення FileStream для запису в файл "example.txt"
        public void CreateFileStream()
        {
            // Вказуємо шлях до файлу, з яким будемо працювати
            string filePath = "example_with_FileStream.txt";

            Console.WriteLine(Path.GetFullPath(filePath));

            // Відкриваємо файл для запису. Якщо файлу немає — він створиться.
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                byte[] data = { 72, 101, 108, 108, 111 }; // Це слово "Hello" в байтах (ASCII) // https://www.ascii-code.com/
                // string text = "Hello";
                // перетворюємо текст в байти 
                // byte[] data = System.Text.Encoding.UTF8.GetBytes(text);

                fs.Write(data, 0, data.Length);
            }

            // Тепер відкриємо цей файл для читання і зчитаємо перші 5 байтів, щоб побачити, що ми записали
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[5]; // Буфер для зчитування 5 байтів
                fs.Read(buffer, 0, buffer.Length);
                string text = System.Text.Encoding.UTF8.GetString(buffer);
                Console.WriteLine(text); // Виведе "Hello"
            }
        }

        // Методи FileStream
        // FileStream.Write(byte[] buffer, int offset, int count) — записує байти з масиву buffer в потік, починаючи з позиції offset і записуючи count байтів.
        // FileStream.Read(byte[] buffer, int offset, int count) — читає байти з потока в масив buffer, починаючи з позиції offset і читаючи до count байтів. Повертає фактичну кількість прочитаних байтів.
        // FileStream.Seek(long offset, SeekOrigin origin) — переміщує позицію в потоці на задану кількість байтів (offset) відносно точки відліку (origin).
        // FileStream.Flush() — очищає буфер і записує всі дані в базовий потік (наприклад, на диск).
        // FileStream.Close() — закриває потік і звільняє всі ресурси, повʼязані з ним. Після цього потік більше не можна використовувати.
        // FileStream.Dispose() — звільняє всі ресурси, повʼязані з потоком. Викликається автоматично при використанні конструкції using.
        // FileStream.Length — повертає довжину потока в байтах.
        // FileStream.Position — повертає або встановлює поточну позицію в потоці в байтах.
        // FileStream.SetLength(long value) — встановлює довжину потока в байтах. Якщо нова довжина менша за поточну, дані в кінці потока будуть втрачені. Якщо нова довжина більша, потік буде доповнений нулями.
        // FileStream.CopyTo(Stream destination) — копіює всі байти з потока в інший потік (destination).
        

        // Проблема "Сирих Даних" та Рішення
        // FileStream працює з "сирими даними" — це просто байти. Якщо ви хочете працювати з текстом, вам потрібно перетворити його в байти (наприклад, за допомогою кодування UTF-8).
        // Це може бути незручно, тому в .NET є більш високорівневі класи:

        // StreamWriter — для запису тексту в поток (він автоматично перетворює текст в байти).
        // StreamReader — для читання тексту з потока (він автоматично перетворює байти в текст).

        //Чому це важливо розуміти?
        // Розуміння того, що FileStream працює з байтами, допомагає нам краще розуміти, як працюють потоки в .NET і які інструменти використовувати для різних типів даних.
        // Якщо ви хочете працювати з текстом, використовуйте StreamReader/StreamWriter. Якщо вам потрібно працювати з бінарними даними (наприклад, зображеннями, аудіо, відео), тоді FileStream буде більш підходящим вибором.

        // Чому не використоти File.WriteAllText() або File.ReadAllText()?
        // Ці методи зручні для простих випадків, але вони завантажують весь файл в пам'ять.
        // Якщо файл дуже великий, це може призвести до проблем з продуктивністю або навіть до вичерпання пам'яті та помилки OutOfMemoryException

        // Ще є BinaryWriter та BinaryReader для роботи з бінарними даними,
        // але вони все одно працюють з байтами, просто надають зручні методи для запису різних типів даних
        // (int, float, string і т.д.)
        // без необхідності вручну перетворювати їх в байти.
        // Наприклад, з BinaryWriter ви можете просто викликати Write(int value), і він автоматично запише це ціле число в потік у вигляді байтів.
        // Також можна використовувати для картинок, аудіо, відео та інших типів даних, які не є текстом.


    }
}
