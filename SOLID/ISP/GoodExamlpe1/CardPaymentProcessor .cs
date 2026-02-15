namespace ISP.GoodExamlpe1
{
    internal class CardPaymentProcessor: IPayment, IRefundable, ICardPayment
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
