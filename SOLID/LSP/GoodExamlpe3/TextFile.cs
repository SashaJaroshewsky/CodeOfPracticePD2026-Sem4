namespace LSP.GoodExamlpe3
{
    public class TextFile : IWritableDocument
    {
        public void Open() => Console.WriteLine("Відкрито.");
        public void Save() => Console.WriteLine("Збережено.");
    }
}
