namespace LSP.BadExample3
{
    internal class Invoice : IDocument
    {
        public void Open() => Console.WriteLine("Файл відкрито для читання.");

        public void Save()
        {
            // Ми не можемо зберегти. 
            // Що робить розробник-початківець? Викидає помилку.
            throw new NotSupportedException("Неможливо зберегти файл тільки для читання!");
        }
    }
}
