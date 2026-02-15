namespace LSP.BadExample3
{
    public class TextFile : IDocument
    {
        public void Open() => Console.WriteLine("Відкрито текстовий файл. Можна читати й редагувати");
        public void Save() => Console.WriteLine("Текстовий файл збережено.");
    }
}
