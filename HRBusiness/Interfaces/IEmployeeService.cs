using System;
namespace HR.Business.Interfaces;

public interface IEmployeeService
{
	public void Create(string? name,string? surname,int? salary);
	public void Deactive(int? id);
	public void ShowAll();
	public void ChangeDepartment(int? departId,int? employeeId);
	public void İncreaseEmployeeSalary(int? employeeId, int? increaseSalary);
	public void DecreaseEmployeeSalary(int? employeeId, int? decreaseSalary);
}

