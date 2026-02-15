namespace LSP.GoodExamlpe3
{
    // Рівень вище - читання + запис
    internal interface IWritableDocument : IReadableDocument
    {
        void Save();
    }
}
