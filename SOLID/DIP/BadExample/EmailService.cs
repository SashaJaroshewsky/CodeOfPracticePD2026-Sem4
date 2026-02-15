namespace DIP.BadExample
{
    internal class EmailService
    {
        public void SendEmail(string email, decimal total)
        {
            // Логіка відправки електронної пошти
            Console.WriteLine($"Sending email to {email}");
            Console.WriteLine($"Order total: {total}");
        }
    }
}
