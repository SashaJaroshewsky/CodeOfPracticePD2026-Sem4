namespace LSP.BadExample4
{
    // “Вона ж виглядає як качка!”
    internal class ElectronicDuck : Duck
    {
        public override void Quack()
        {
            Console.WriteLine("Electronic quack sound");
        }

        public override void Swim()
        {
            throw new NotSupportedException();
        }

        public override void Fly()
        {
            throw new NotSupportedException();
        }
    }
    // Але LSP каже:

    //“Мене не цікавить, як вона виглядає.
    //Мене цікавить, чи вона поводиться як качка.”
}
