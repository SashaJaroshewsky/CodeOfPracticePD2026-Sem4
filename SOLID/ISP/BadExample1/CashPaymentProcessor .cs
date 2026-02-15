namespace ISP.BadExample1
{
    internal class CashPaymentProcessor : IPaymentProcessor
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine("Paying by cash...");
        }

        public void Refund(decimal amount)
        {
            Console.WriteLine("Refund cash...");
        }

        public void SaveCard(string cardNumber)
        {
            throw new NotSupportedException();
        }

        public void Validate3DS()
        {
            throw new NotSupportedException();
        }
    }
}
