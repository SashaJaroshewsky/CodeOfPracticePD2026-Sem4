namespace DIP.GoodExample
{
    // Тепер що змінилось?
    // OrderService залежить від абстрактних інтерфейсів, а не від конкретних реалізацій.
    // Бізнес-логіка не знає про SQL
    // Бізнес-логіка не знає про Email
    // Легко замінити реалізації
    // Легко тестувати

    // Чому це називається “Inversion” (інверсія)?
    // Тому що ми інвертували залежності: замість того, щоб OrderService залежав від конкретних класів (SQLOrderRepository, EmailNotificationService),
    // ми зробили так, щоб він залежав від абстрактних інтерфейсів (IOrderRepository, INotificationService).
    // Тепер конкретні реалізації можуть бути "впроваджені" (injected) в OrderService ззовні, що робить код більш гнучким і менш зв'язаним.
    public class OrderService
    {
        private readonly IOrderRepository _repository;
        private readonly INotificationService _notification;

        public OrderService(
            IOrderRepository repository,
            INotificationService notification)
        {
            _repository = repository;
            _notification = notification;
        }

        public void CreateOrder(decimal total, string email)
        {
            _repository.Save(total);
            _notification.Send(email, total);
        }
    }
}
