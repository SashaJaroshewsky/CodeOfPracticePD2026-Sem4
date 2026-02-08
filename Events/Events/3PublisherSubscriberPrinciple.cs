namespace Events
{
    internal class PublisherSubscriberPrinciple
    {
        // Принцип видавця-підписника (Publisher-Subscriber) є патерном проектування,
        // який дозволяє об'єктам (видавцям) повідомляти інші об'єкти (підписників) про певні події без прямого зв'язку між ними.

        // У цьому патерні видавець публікує події, а підписники підписуються на ці події та реагують на них, коли вони відбуваються.

        //Publisher
        public class NewsPublisher
        {
            // Делегат для події новин
            public delegate void NewsEventHandler(string news);
            // Подія новин
            public event NewsEventHandler NewsPublished;
            // Метод для публікації новин
            public void PublishNews(string news)
            {
                Console.WriteLine("Publishing News: " + news);
                // Виклик події
                NewsPublished?.Invoke(news);
            }
        }

        //Subscriber
        public class NewsSubscriber
        {
            private string _name;
            public NewsSubscriber(string name)
            {
                _name = name;
            }
            // Метод для підписки на подію новин
            public void Subscribe(NewsPublisher publisher)
            {
                publisher.NewsPublished += OnNewsPublished;
            }
            // Обробник події новин
            private void OnNewsPublished(string news)
            {
                Console.WriteLine($"{_name} received news: {news}");
            }
        }

        // Приклад використання
        public void Example()
        {
            // Створення видавця новин
            NewsPublisher publisher = new NewsPublisher();
            // Створення підписників
            NewsSubscriber subscriber1 = new NewsSubscriber("Subscriber 1");
            NewsSubscriber subscriber2 = new NewsSubscriber("Subscriber 2");
            // Підписка на подію новин
            subscriber1.Subscribe(publisher);
            subscriber2.Subscribe(publisher);
            // Публікація новин
            publisher.PublishNews("Breaking News: New Event System Implemented!");
            publisher.PublishNews("Update: Event System Working Smoothly.");
        }
    }
}
