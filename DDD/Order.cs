namespace DDD;

public class DeliveryAddress
{  
    public string Street { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public DeliveryAddress(string street, string city, string postalCode)
    {
        
        if (string.IsNullOrWhiteSpace(street))
        {
            throw new ArgumentException("Поле улицы в адресе не может быть пустым или состоять только из пробелов");
        }
        if (string.IsNullOrWhiteSpace(city))
        {
            throw new ArgumentException("Поле города в адресе не может быть пустым или состоять только из пробелов");
        }
        if (string.IsNullOrWhiteSpace(postalCode))
        {
            throw new ArgumentException("Поле индекса в адресе не может быть пустым или состоять только из пробелов");
        }

        Street = street;
        City = city;
        PostalCode = postalCode;
    }
}

public class Status
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Status(int id, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Название статуса не может быть пустым или состоять только из пробелов");
        }

        Id = id;
        Name = name;
    }
}


public class Order
{
    public string Id { get; set; }
    public List<Product> Products { get; set; }
    public DeliveryAddress DeliveryAddress { get; set; }
    public Status Status { get; set; }

    public Order(string id, List<Product> products, DeliveryAddress deliveryAddress, Status status)
    {
        if (products.Count == 0)
            throw new ArgumentException("Заказ должен содержать хотя бы один продукт.");
        
        Id = id;
        Products = products;
        DeliveryAddress = deliveryAddress;
        Status = status;
    }
}

public class OrderRepository
{
    public void Save(Order order)
    {
    }
}

public class OrderFactory
{
    public Order CreateOrder(string id, List<Product> products, DeliveryAddress deliveryAddress, Status status)
    {
        return new Order(id, products, deliveryAddress, status);
    }
}

public class DeliveryCostCalculator
{
    public double CalculateCost(Order order)
    {
        return 0.0;
    }
}
