namespace SRP.GoodExamlpe
{
    // Цей клас відповідає лише за відправку електронних листів, пов'язаних із замовленнями.
    internal class EmailService
    {
        public void SendEmail(string email, decimal total)
        {
            Console.WriteLine($"Email sent to {email} with order total: {total}");
        }
    }
}
