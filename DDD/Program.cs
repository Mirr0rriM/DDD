using DDD;

class Program
{
    static void Main()
    {
        var productRepository = new ProductRepository();
        var orderRepository = new OrderRepository();
        var userRepository = new UserRepository();
        var deliveryCostCalculator = new DeliveryCostCalculator();

        
        var product = productRepository.GetProductById("1");

        var user = userRepository.GetUserById("1");

        var deliveryAddress = new DeliveryAddress("123 Main St", "City", "12345");
        var status = new Status(3, "Доставляется");
        var Service = new Service(orderRepository, deliveryCostCalculator);
        var order = Service.CreateOrder(new List<Product>{product}, deliveryAddress, status);

        Console.WriteLine($"Продукт: {product.Name}");
        Console.WriteLine($"Цена: {product.Price.Value} рублей");
        Console.WriteLine($"Пользователь: {user.Name} {user.SecondName}");
        Console.WriteLine($"ID заказа: {order.Id}");
        Console.WriteLine($"Стоимость доставки: {deliveryCostCalculator.CalculateCost(order)} рублей"); 
        Console.WriteLine($"Способ оплаты: {user.TypeOfPay}");
        Console.WriteLine($"Тип: {user.TypeOfCard}");
    }
}