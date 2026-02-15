namespace LSP.GoodExamlpe3
{
    internal class DocumentEditor
    {
        // Цей метод приймає ВСІ документи. Він безпечний.
        public void OpenEverything(List<IReadableDocument> docs)
        {
            foreach (var doc in docs)
            {
                doc.Open(); // Жодних помилок!
            }
        }

        // Цей метод ПРИЙМАЄ ТІЛЬКИ ті, що можна зберігати.
        // Ви фізично не зможете передати сюди ReadOnlyDocument.
        public void SaveChanges(List<IWritableDocument> docs)
        {
            foreach (var doc in docs)
            {
                doc.Save(); // Гарантована безпека.
            }
        }
    }
}
