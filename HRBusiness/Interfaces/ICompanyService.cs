using System;
namespace HR.Business.Interfaces;

public interface ICompanyService
{
	public void Create(string name);
	public void Deactive(string? name);
	public void GetAllDepartment(string? name);
	public void ShowAll();
	public void FindCompanyWithId(int? id);
	public void ShowAllCompanyId();
}

