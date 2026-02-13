using SRP.GoodExamlpe;

namespace SRP
{
    internal class Program
    {
        // Single Responsibility Principle - Принцип єдиної відповідальності
        // Клас повинен мати лише одну причину для зміни, тобто він повинен виконувати лише одну функцію або відповідальність.
        // Це означає, що кожен клас повинен бути відповідальним лише за одну частину функціональності програми.
        // Якщо клас виконує більше однієї функції, він може стати складним для підтримки та розширення, оскільки зміни в одній функції можуть вплинути на інші функції.
        static void Main(string[] args)
        {
            OrderRepository orderRepository = new OrderRepository();
            EmailService emailService = new EmailService();
            OrderCalculator orderCalculator = new OrderCalculator();

            var orderService = new OrderService(orderRepository, emailService, orderCalculator);
            var order = new List<decimal> { 100, 200, 300 };
            orderService.CreateOrder(order, "CSharp@gmail.com");
        }
    }
}


