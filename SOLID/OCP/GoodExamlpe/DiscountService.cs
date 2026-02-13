namespace OCP.GoodExamlpe
{
    // Цей клас відповідає за застосування знижок до загальної суми.
    // Він використовує інтерфейс IDiscount для застосування різних типів знижок, не змінюючи свій код при додаванні нових знижок.
    internal class DiscountService
    {
        public decimal ApplyDiscount(decimal total, IDiscount discount)
        {
            return discount.ApplyDiscount(total);
        }
    }
}
