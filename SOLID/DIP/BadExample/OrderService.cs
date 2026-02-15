namespace DIP.BadExample
{
    // OrderService — це високорівневий модуль (бізнес-логіка).
    // EmailService і SqlOrderRepository — це низькорівневі модулі (технічні деталі).
    // Вони всі тісно пов'язані між собою, що порушує принцип інверсії залежностей.
    // Якщо ми хочемо змінити спосіб збереження замовлення або надсилання електронного листа,
    // нам доведеться змінювати код OrderService, що робить його менш гнучким і складним для підтримки.

    // 
    internal class OrderService
    {
        private EmailService _emailService = new EmailService();
        private SqlOrderRepository _repository = new SqlOrderRepository();

        public void CreateOrder(decimal total, string email)
        {
            _repository.Save(total);
            _emailService.Send(email, total);
        }
    }
}
