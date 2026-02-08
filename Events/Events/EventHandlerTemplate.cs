namespace Events
{
    internal class EventHandlerTemplate
    {
        // EventHandler це вбудований делегат в C#, який використовується для визначення подій.
        // Він має наступну сигнатуру:
        // public delegate void EventHandler(object sender, EventArgs e);
        // Де:
        // - sender: це об'єкт, який викликає подію. Зазвичай це той об'єкт, на якому сталася подія.
        // - e: це об'єкт типу EventArgs або його похідного класу, який містить додаткову інформацію про подію.

        // Використання EventHandler дозволяє створювати події, які можуть передавати інформацію про те, що сталося, а також об'єкт, який викликав цю подію.
        // Це робить код більш гнучким і дозволяє обробникам подій отримувати необхідні дані для виконання своїх завдань.
        // Ось приклад використання EventHandler:

        // Визначення класу з подією
        public class SampleEventPublisher
        {
            // Оголошення події з використанням EventHandler
            public event EventHandler SampleEvent;
            // Метод для виклику події
            public void OnSampleEvent()
            {
                // Виклик події, якщо є підписники
                //SampleEvent(this, EventArgs.Empty);
                SampleEvent?.Invoke(this, new ExampleEventArgs("Контекст івенту"));
            }
        }

        // Визначення класу, який підписується на подію
        public class SampleEventSubscriber
        {
            // Метод-обробник події
            // sender = об'єкт, який викликав подію / ХТО
            // e = додаткові дані про подію / ЩО СТАЛОСЯ
            public void HandleSampleEvent(object sender, EventArgs e)
            {
                Console.WriteLine("SampleEvent was triggered.");
                // Додаткова логіка обробки події може бути додана тут
                // Наприклад, можна отримати доступ до об'єкта sender, якщо потрібно
                SampleEventPublisher publisher = sender as SampleEventPublisher;
                if (publisher != null)
                {
                    // Виконати дії з об'єктом publisher, якщо потрібно
                }
                if (e is ExampleEventArgs exampleEventArgs)
                {
                    Console.WriteLine($"Message from event: {exampleEventArgs.Message}");
                }

            }
        }

        public class ExampleEventArgs : EventArgs
        {
            public string Message { get; set; }
            public ExampleEventArgs(string message)
            {
                Message = message;
            }
        }

            public void Example()
        {
            // Створення видавця події
            SampleEventPublisher publisher = new SampleEventPublisher();
            // Створення підписника події
            SampleEventSubscriber subscriber = new SampleEventSubscriber();
            // Підписка на подію
            publisher.SampleEvent += subscriber.HandleSampleEvent;
            // Виклик події
            publisher.OnSampleEvent();
        }
    }
}
