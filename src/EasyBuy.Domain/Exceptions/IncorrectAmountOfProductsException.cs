namespace EasyBuy.Domain.Exceptions
{
    public class IncorrectAmountOfProductsException : CustomException
    {
        public int Amounts { get; }

        public IncorrectAmountOfProductsException(int amounts) : base($"Product amounts: {amounts} is invalid")
            => Amounts = amounts;
    }
}
