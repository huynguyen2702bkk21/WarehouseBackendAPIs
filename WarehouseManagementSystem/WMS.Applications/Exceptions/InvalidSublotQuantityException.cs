namespace WMS.Application.Exceptions
{
    [Serializable]
    public class InvalidSublotQuantityException : Exception
    {
        public InvalidSublotQuantityException(string message) : base(message)
        {

        }
    }
}
