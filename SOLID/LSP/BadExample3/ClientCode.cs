namespace LSP.BadExample3
{
    internal class ClientCode
    {
        public void SaveAllDocuments(List<IDocument> docs)
        {
            foreach (var doc in docs)
            {
                if (doc is not Invoice) 
                doc.Save(); // Тут програма "впаде", якщо в списку буде Invoice
            }
        }
    }
}
