namespace LSP.BadExample2
{
    internal class ClientCode
    {
        public void ResizeRectangle(Rectangle rect)
        {
            rect.Width = 10;
            rect.Height = 5;

            // Клієнт очікує: Площа = 10 * 5 = 50
            // Але якщо прийшов Square: Площа буде 5 * 5 = 25 (бо висота перетерла ширину)

            rect.GetArea();
        }
    }
}
