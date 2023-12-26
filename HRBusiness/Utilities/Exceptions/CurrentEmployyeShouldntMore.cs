using System;
namespace HR.Business.Utilities.Exceptions
{
	public class CurrentEmployyeShouldntMore:Exception
	{
		public CurrentEmployyeShouldntMore(string message):base(message) { }
	}
}

