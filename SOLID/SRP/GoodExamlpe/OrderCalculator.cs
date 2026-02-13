namespace SRP.GoodExamlpe
{
    // Цей клас відповідає лише за обчислення загальної суми замовлення, не займаючись іншими аспектами. 
    internal class OrderCalculator
    {
        public decimal CalculateTotal(List<decimal> prices)
        {
            return prices.Sum();
        }
    }
}
