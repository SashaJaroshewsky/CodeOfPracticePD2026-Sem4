namespace SRP.GoodExamlpe
{
    // Цей клас відповідає лише за створення замовлення, а не за всі аспекти, пов'язані з ним.
    // Він лише координує роботу інших класів, які відповідають за конкретні завдання.
    internal class OrderService
    {
        private readonly OrderRepository _orderRepository;
        private readonly EmailService _emailService;
        private readonly OrderCalculator _orderCalculator;
        public OrderService(OrderRepository orderRepository, EmailService emailService, OrderCalculator orderCalculator)
        {
            _orderRepository = orderRepository;
            _emailService = emailService;
            _orderCalculator = orderCalculator;
        }
        public void CreateOrder(List<decimal> prices, string email)
        {
           var total = _orderCalculator.CalculateTotal(prices);
            _orderRepository.SaveOrder(total);
            _emailService.SendEmail(email, total);
        }
        
    }

}
