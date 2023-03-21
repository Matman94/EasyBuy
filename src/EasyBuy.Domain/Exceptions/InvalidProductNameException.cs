namespace EasyBuy.Domain.Exceptions
{
    public class InvalidProductNameException : CustomException
    {
        public string Name { get; }

        public InvalidProductNameException(string name) : base($"Product name: {name} is invalid")
            => Name = name;
    }
}
