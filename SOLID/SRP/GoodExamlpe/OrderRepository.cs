namespace SRP.GoodExamlpe
{
    // Цей клас відповідає лише за збереження замовлення, не займаючись іншим.
    internal class OrderRepository
    {
        public void SaveOrder(decimal total)
        {
            Console.WriteLine($"Order saved with total: {total}");
        }
    }
}
