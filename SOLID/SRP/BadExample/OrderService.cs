namespace SRP.BadExample
{
    internal class OrderService
    {
        public void CreateOrder(List<decimal> prices, string email)
        {
            decimal total = CalculateTotal(prices);
            SaveToDatabase(total);
            SendEmail(email, total);
        }

        private decimal CalculateTotal(List<decimal> prices)
        {
            // Бізнес-логіка
            if (prices == null || prices.Count == 0)
                throw new ArgumentException("Order must contain at least one item");

            decimal total = prices.Sum();

            // Податок
            total += total * 0.2m;

            // Логування
            Console.WriteLine($"Order total calculated: {total}");

            return total;
        }

        private void SaveToDatabase(decimal total)
        {
            // Уявна робота з БД
            Console.WriteLine("Connecting to SQL Server...");
            Console.WriteLine($"Saving order with total: {total}");
        }

        private void SendEmail(string email, decimal total)
        {
            // Уявна інтеграція з email-сервісом
            Console.WriteLine($"Sending email to {email}");
            Console.WriteLine($"Order total: {total}");
        }
    }

    // Чому цей код порушує принцип єдиної відповідальності?
    // Клас OrderService виконує кілька різних функцій: він обчислює загальну суму замовлення, зберігає його в базі даних і надсилає електронного листа.

    // Що зміниться, якщо:
    // 1. Змінимо логіку обчислення загальної суми (наприклад, додамо знижку) - це може вплинути на логіку збереження та надсилання електронного листа, оскільки вони залежать від загальної суми.
    // 2. Змінимо спосіб збереження замовлення (наприклад, перейдемо на іншу базу даних)
    // 3. Змінимо спосіб надсилання електронного листа (наприклад, перейдемо на інший email-сервіс)
    // У всіх цих випадках ми ризикуємо порушити інші функції класу, оскільки вони всі взаємопов'язані. Це робить код складним для підтримки та розширення.

    // Щоб дотримуватись SRP задавайте собі питання: "Чому цей клас може змінитися?" Якщо відповідь на це питання більше одного,
    // то клас порушує принцип єдиної відповідальності і його слід розділити на кілька класів, кожен з яких відповідає за одну конкретну функцію.

}