namespace Delegates
{
    public delegate void MyDelegate(string message);// Оголошення делегата поза класом
    internal class DelegateAnnouncement
    {
        // Делегат можна оголосити делегат безпосередньо всередині класу або поза ним.

        // Різниця полягає в області видимості та доступності делегата.
        // Оголошення делегата всередині класу робить його доступним лише в межах цього класу або його похідних класів,
        // тоді як оголошення делегата поза класом робить його доступним для всього простору імен або навіть для інших просторів імен, якщо він оголошений як public.
        // Вибір між цими двома підходами залежить від того, наскільки широко ви хочете використовувати делегат у вашому коді.

        // Оголошення делегата всередині класу
        public delegate void AnotherDelegate(int number);

        //Делегати без параметрів
        public delegate void NoParameterDelegate();

        //Делегати з поверненням значення
        public delegate string ReturnValueDelegate();

        // Делегати з кількома параметрами та поверненням значення
        public delegate int MultipleParametersDelegate(int a, int b, int c);

        // Делегати з параметрами за замовчуванням
        public delegate void DefaultParameterDelegate(string message = "Hello, World!");
        // Делегати з параметрами типу посилання
        public delegate void RefParameterDelegate(ref int number);
        // Делегати з параметрами типу вихідних даних
        public delegate void OutParameterDelegate(out int result);
        // Делегати з параметрами змінної довжини
        public delegate void ParamsDelegate(params int[] numbers);
  
    }
}
