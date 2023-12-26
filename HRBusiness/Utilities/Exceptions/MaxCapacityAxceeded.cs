using System;
namespace HR.Business.Utilities.Exceptions;

public class MaxCapacityAxceeded:Exception
{
	public MaxCapacityAxceeded(string message) : base(message) { }
}

