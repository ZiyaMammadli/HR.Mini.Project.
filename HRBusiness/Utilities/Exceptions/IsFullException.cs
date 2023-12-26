using System;
namespace HR.Business.Utilities.Exceptions;

public class IsFullException:Exception
{
	public IsFullException(string message) : base(message) { }
}

