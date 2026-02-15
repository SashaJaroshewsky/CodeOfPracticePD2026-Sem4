namespace ISP.BadExample1
{
    internal class CardPaymentProcessor: IPaymentProcessor
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine("Paying by card...");
        }

        public void Refund(decimal amount)
        {
            Console.WriteLine("Refund to card...");
        }

        public void SaveCard(string cardNumber)
        {
            Console.WriteLine("Saving card...");
        }

        public void Validate3DS()
        {
            Console.WriteLine("Validating 3DS...");
        }
    }
}
