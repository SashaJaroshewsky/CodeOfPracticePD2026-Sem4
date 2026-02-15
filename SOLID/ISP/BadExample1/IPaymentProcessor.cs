namespace ISP.BadExample1
{
    internal interface IPaymentProcessor
    {
        void Pay(decimal amount);
        void Refund(decimal amount);
        void SaveCard(string cardNumber);
        void Validate3DS();
    }
}
