namespace LSP.GoodExamlpe4
{
    public class RealDuck : IQuackable, ISwimmable, IFlyable
    {
        public void Quack() => Console.WriteLine("Quack");
        public void Swim() => Console.WriteLine("Swimming...");
        public void Fly() => Console.WriteLine("Flying...");
    }
}
