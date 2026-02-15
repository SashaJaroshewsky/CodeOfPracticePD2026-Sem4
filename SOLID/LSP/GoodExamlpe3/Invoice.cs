namespace LSP.GoodExamlpe3
{
    internal class Invoice : IReadableDocument
    {
        public void Open() => Console.WriteLine("Відкрито тільки для читання.");

    }
}
