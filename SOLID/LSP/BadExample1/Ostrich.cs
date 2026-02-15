namespace LSP.BadExample1
{
    internal class Ostrich: Bird
    {
        public void Run() => Console.WriteLine("Страус біжить.");
        public override void Fly() => throw new NotSupportedException("Страуси не літають!");
        // Це ГРУБЕ порушення LSP
    }
}
