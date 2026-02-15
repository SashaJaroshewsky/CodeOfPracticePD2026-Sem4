namespace LSP.BadExample4
{
    internal class RealDuck : Duck
    {
        public override void Quack()
        {
            Console.WriteLine("Quack");
        }

        public override void Swim()
        {
            Console.WriteLine("Swimming...");
        }

        public override void Fly()
        {
            Console.WriteLine("Flying...");
        }
    }
}
