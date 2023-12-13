namespace DDD;

public class User
{
    public string Id { get; }
    public string Name { get; }
    public string SecondName { get; }
    public string TypeOfPay { get; }
    public string TypeOfCard { get; }

    public User(string id, string name, string secondName, string typeOfPay, string typeOfCard)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Имя пользователя не может быть пустым или состоять только из пробелов");
        }
        if (string.IsNullOrWhiteSpace(secondName))
        {
            throw new ArgumentException("Фамилия пользователя не может быть пустой или состоять только из пробелов");
        }
        if (string.IsNullOrWhiteSpace(typeOfCard))
        {
            throw new ArgumentException("Тип карты не может быть пустым или состоять только из пробелов");
        } 
        if (string.IsNullOrWhiteSpace(typeOfPay))
        {
            throw new ArgumentException("Метод оплаты не может быть пустым или состоять только из пробелов");
        }
        
        Id = id;
        Name = name;
        SecondName = secondName;
        TypeOfPay = typeOfPay;
        TypeOfCard = typeOfCard;
    }
}

public class UserFabric
{
    public User CreateUser(string id, string name, string secondName, string typeOfPay, string typeOfCard)
    {
        return new(id, name, secondName, typeOfPay, typeOfCard);
    }
   
}

public class UserRepository
{
    public User GetUserById(string userId)
    {
        return new User("1", "John", "Doe", "банковкая карта", "дебетовая");
    }
}
