namespace LSP.GoodExamlpe2
{
    internal class ClientCode
    {
        public void ResizeShape(Shape shape)
        {
            // Тепер ніхто не може змінити ширину "тишком-нишком", зламавши логіку іншого поля.
            // Клієнт може працювати з будь-якою фігурою, яка реалізує Shape
            // Він не знає і не турбується про конкретний тип фігури
            double area = shape.GetArea();
            Console.WriteLine($"Площа фігури: {area}");
        }
    }
}
