using System.Runtime.Serialization;

[Serializable]
internal class CartItemQuantityException : Exception
{
    public CartItemQuantityException()
    {
    }

    public CartItemQuantityException(string? message) : base(message)
    {
    }

    public CartItemQuantityException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected CartItemQuantityException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}