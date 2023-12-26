using System;
namespace HR.Business.Utilities.Exceptions
{
	public class AlreadyWorkOtherDepartment:Exception
	{
		public AlreadyWorkOtherDepartment(string message) : base(message) { }
	}
}

