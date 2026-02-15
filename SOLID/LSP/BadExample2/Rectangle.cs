namespace LSP.BadExample2
{
    internal class Rectangle
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }
        public int GetArea() => Width * Height;
    }
}
