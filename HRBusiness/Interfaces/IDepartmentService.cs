using System;
using HR.Core.Entities;

namespace HR.Business.Interfaces;

public interface IDepartmentService
{
	public void Create(string? name,int? employeelimit,int companyid);
	public void Deactive(int? id);
	public void AddEmployee(int? employeeId, int? departId); //employee obyektinin departamentid-ne bu departamentin id-in set edir..
	public void UpdateDepartment(int? departId,string? newName, int employeeLimit);
	public void GetDepartmentEmployees(int? id);
	public void ShowDepartmentDetails(int? id);
	public void ShowAll();


}

