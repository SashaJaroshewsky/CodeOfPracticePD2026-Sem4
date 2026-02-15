namespace LSP.GoodExample1
{
    internal class Eagle: Bird
    {
        public override void Move() => Fly();
        public  void Fly() => Console.WriteLine("Орел летить");
    }
}
