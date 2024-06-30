namespace Pinewood.Exceptions
{
	public class CustomerNullException : Exception
	{
		public CustomerNullException()
		{
			
		}

		public CustomerNullException(string message) : base(message)
		{
			
		}

		public CustomerNullException(string message, Exception innerException) : base(message, innerException)
		{
			
		}
	}
}
