namespace DIP.GoodExample
{
    public class SqlOrderRepository : IOrderRepository
    {
        public void Save(decimal total)
        {
            Console.WriteLine("Saving order to SQL Server...");
        }
    }
}
