namespace LSP.GoodExamlpe2
{
    internal class Square
    {
        public double Side { get; set; }
        public Square(double side)
        {
            Side = side;
        }
        public double GetArea()
        {
            return Side * Side;
        }
    }
}
