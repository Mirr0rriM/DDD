namespace DDD;

using System;

public class Price
{
    public double Value { get; set; }
}

public class Product
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Price Price { get; set; }

    public Product(string id, string name, string description, Price price)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Имя продукта не может быть пустым или состоять только из пробелов.", nameof(name));
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Описание продукта не может быть пустым или состоять только из пробелов.", nameof(description));
        if (price.Value <= 0)
            throw new ArgumentException("Цена продукта должна быть положительным числом.", nameof(price));

        Id = id;
        Name = name;
        Description = description;
        Price = price;
    }
}

public class ProductRepository
{
    public Product GetProductById(string productId)
    {
        return new Product("1", "Example Product", "Description", new Price { Value = 2329.59 });
    }
}

public class ProductFactory
{
    public Product CreateProduct(string id, string name, string description, Price price)
    {
        return new Product(id, name, description, price);
    }
}
