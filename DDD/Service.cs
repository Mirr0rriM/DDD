namespace DDD;

public class Service
{
    private readonly OrderRepository _orderRepository;
    private readonly DeliveryCostCalculator _deliveryCostCalculator;

    public Service(OrderRepository orderRepository, DeliveryCostCalculator deliveryCostCalculator)
    {
        _orderRepository = orderRepository;
        _deliveryCostCalculator = deliveryCostCalculator;
    }

    public Order CreateOrder(List<Product> products, DeliveryAddress deliveryAddress, Status status)
    {
        var orderFactory = new OrderFactory();
        var order = orderFactory.CreateOrder(Guid.NewGuid().ToString(), products, deliveryAddress, status);
        var deliveryCost = _deliveryCostCalculator.CalculateCost(order);
        _orderRepository.Save(order);
        return order;
    }
}
