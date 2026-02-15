namespace LSP.GoodExample1
{
    internal class Ostrich: Bird
    {
        public override void Move() => Run();
        private void Run() => Console.WriteLine("Страус біжить.");
    }
}
