namespace ISP.GoodExamlpe1
{
    internal class CashPaymentProcessor : IPayment, IRefundable
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine("Paying by cash...");
        }

        public void Refund(decimal amount)
        {
            Console.WriteLine("Refund cash...");
        }
    }
}
