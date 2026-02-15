namespace DIP.GoodExample
{
    public class EmailService : INotificationService
    {
        public void Send(string email, decimal total)
        {
            Console.WriteLine("Sending email...");
        }
    }
}
