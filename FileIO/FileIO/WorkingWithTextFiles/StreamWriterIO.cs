namespace FileIO.WorkingWithTextFiles
{
    // StreamWriter — для запису тексту в поток (він автоматично перетворює текст в байти).
    // Що він робить під капотом?
    // StreamWriter — це "перекладач". Він бере ваші string або char, дивиться на обране кодування (Encoding), перетворює символи на байти та складає їх у буфер.
    // Коли буфер заповнюється, він "виштовхує" (Flush) ці байти в базовий потік (наприклад, FileStream).

    // Покрокова робота StreamWriter:
    // 1. Ви створюєте StreamWriter, вказуючи шлях до файлу або базовий потік (наприклад, FileStream).
    // 2. Ви викликаєте методи Write або WriteLine, передаючи текст, який хочете записати.
    // 3. StreamWriter перетворює цей текст у байти за допомогою вибраного кодування (за замовчуванням UTF-8) і зберігає їх у внутрішньому буфері.
    // 4. Коли буфер заповнюється або коли ви викликаєте Flush() або коли StreamWriter закривається, він записує ці байти в базовий потік (наприклад, FileStream), який потім записує їх на диск.
    // 5. Після закриття StreamWriter, він автоматично закриває свій базовий потік (якщо він його створив), що забезпечує правильне звільнення ресурсів.

    // Використання StreamWriter робить роботу з текстовими файлами набагато зручнішою, оскільки вам не потрібно турбуватися про перетворення тексту в байти та керування буфером — все це робить за вас StreamWriter.

    internal class StreamWriterIO
    {
        // Використовуємо StreamWriter для запису тексту в файл
        public void CreateFileStreamWithStreamWriter()
        {
            // Вказуємо шлях до файлу, з яким будемо працювати
            string filePath = "example_with_StreamWriter.txt";
            // Використовуємо StreamWriter, який працює поверх FileStream і дозволяє нам зручно записувати текст
            // StreamWriter автоматично створить FileStream для нас, якщо ми вкажемо шлях до файлу
            // Якщо файлу немає — він створиться. Якщо файл вже існує, він буде перезаписаний (залежно від режиму відкриття).
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine("Hello, World!");
                sw.WriteLine("This is a StreamWriter example. Це зручніше)");
            }
            // Після закриття using, StreamWriter автоматично закриє свій внутрішній FileStream, що забезпечує правильне звільнення ресурсів.
            // Це потрібно розуміти, щоб уникнути проблем з блокуванням файлів або витоками ресурсів.
        }

        //Основні конструктори StreamWriter:
        // StreamWriter(string path) — створює StreamWriter, який записує в файл за вказаним шляхом. Якщо файл не існує, він буде створений.
        // StreamWriter(Stream stream) — створює StreamWriter, який записує в базовий потік (наприклад, FileStream). Ви повинні забезпечити, що цей потік підтримує запис.
        // StreamWriter(string path, bool append) — створює StreamWriter для запису в файл за вказаним шляхом. Якщо append = true, текст буде доданий в кінець файлу, а не перезаписаний.
        // StreamWriter(string path, bool append, Encoding encoding) — створює StreamWriter з можливістю вказати кодування для перетворення тексту в байти.
        // StreamWriter(Stream stream, Encoding encoding) — створює StreamWriter, який записує в базовий потік з вказаним кодуванням.

        // Приклад використання конструктора StreamWriter з різними параметрами:
        public void ConstructorsStreamWriter()
        {
            // Записуємо текст у файл, перезаписуючи його
            using (StreamWriter sw = new StreamWriter("file1.txt"))
            {
                sw.WriteLine("This will overwrite the file if it already exists.");
            }
            // Записуємо текст у файл, додаючи його в кінець
            using (StreamWriter sw = new StreamWriter("file1.txt", true))
            {
                sw.WriteLine("This will be added to the end of the file.");
            }
            // Записуємо текст у файл з вказаним кодуванням (наприклад, UTF-8)
            using (StreamWriter sw = new StreamWriter("file2.txt", false, System.Text.Encoding.UTF8))
            {
                sw.WriteLine("This file is encoded in UTF-8.");
            }
            // Записуємо текст у базовий потік з вказаним кодуванням
            using (FileStream fs = new FileStream("file3.txt", FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8))
                {
                    sw.WriteLine("This file is also encoded in UTF-8, but we created the FileStream ourselves.");
                }
            }
        }

        // Ключові методи StreamWriter:
        // Write(string value) — записує текст без переходу на новий рядок.
        // WriteLine(string value) — записує текст з переходом на новий рядок.
        // Flush() — примусово записує всі буферизовані дані в базовий потік. Це корисно, якщо ви хочете бути впевненими, що всі дані записані на диск, навіть якщо StreamWriter ще не закритий.
        // Close() — закриває StreamWriter і його базовий потік. Після цього StreamWriter більше не можна використовувати.
        // Dispose() — викликається автоматично при використанні конструкції using, забезпечує правильне звільнення ресурсів.
        // Важливо пам'ятати, що після закриття StreamWriter, будь-які спроби запису в нього викличуть помилку ObjectDisposedException,
        // тому завжди потрібно переконатися, що ви не використовуєте StreamWriter після його закриття.

        // Підводні камені (Важливо!)

        // 1. Забутий Dispose/Using: Якщо ви не закриєте StreamWriter (наприклад, не використаєте using або не викличете Dispose()),
        // файл може залишитися заблокованим для інших програм, і ресурси не будуть звільнені.
        // Окрім цього , дані можуть не бути записані на диск, оскільки вони залишаться в буфері StreamWriter. Це може призвести до втрати даних, якщо програма аварійно завершиться.

        // 2. Блокування файлу: Якщо ви відкриєте файл для запису за допомогою StreamWriter, інші програми не зможуть отримати доступ до цього файлу, поки StreamWriter не буде закритий.
        // Це може викликати проблеми, якщо ви намагаєтеся записувати в той же файл з кількох місць або якщо інша програма намагається читати цей файл.

        // 3. AutoFlush: За замовчуванням StreamWriter використовує буферизацію для оптимізації запису.
        // Це означає, що дані можуть не бути записані на диск відразу після виклику Write або WriteLine.
        // Якщо AutoFlush встановлено в true, StreamWriter буде автоматично викликати Flush() після кожного запису,
        // що забезпечує негайне записування даних на диск, але може знизити продуктивність через часті операції вводу/вывода.
        // Якщо AutoFlush встановлено в false (за замовчуванням), вам потрібно вручну викликати Flush(), щоб бути впевненим,
        // що всі дані записані на диск, особливо перед закриттям StreamWriter.


    }
}
