namespace OCP.BadExample
{
    // Цей клас порушує принцип відкритості/закритості, оскільки для додавання нового типу знижки потрібно змінювати код методу ApplyDiscount.
    internal class DiscountService
    {
        public decimal ApplyDiscount(decimal total, string discountType)
        {
            if (discountType == "None")
            {
                return total;
            }
            else if (discountType == "BlackFriday")
            {
                return total * 0.7m;
            }
            else if (discountType == "LoyalCustomer")
            {
                return total * 0.9m;
            }
            else if (discountType == "PromoCode")
            {
                return total - 100;
            }

            throw new ArgumentException("Unknown discount type");
        }
    }
    // Щоб зрозуміти чи ви дотримуєтесь принципу відкритості/закритості, задайте собі питання: "Чи можу я додати новий тип знижки, не змінюючи код методу ApplyDiscount?"
    // Якщо відповідь "ні", то ваш код порушує OCP і його слід рефакторити, наприклад, використовуючи інтерфейси та поліморфізм для реалізації різних типів знижок.
}
