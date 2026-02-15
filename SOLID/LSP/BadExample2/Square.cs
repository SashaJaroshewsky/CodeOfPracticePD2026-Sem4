namespace LSP.BadExample2
{
    internal class Square: Rectangle
    {
        public override int Width
        {
            get => base.Width;
            set
            {
                base.Width = value;
                base.Height = value;
            }
        }
        public override int Height => Width;
        
    }
}
