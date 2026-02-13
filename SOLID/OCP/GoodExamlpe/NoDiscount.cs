namespace OCP.GoodExamlpe
{
    internal class NoDiscount: IDiscount
    {
        public decimal ApplyDiscount(decimal total)
        {
            return total;
        }
    }
}
