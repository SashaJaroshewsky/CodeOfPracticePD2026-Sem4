namespace ISP.GoodExamlpe1
{
    internal interface ICardPayment
    {
        void SaveCard(string cardNumber);
        void Validate3DS();
    }
}
