using System;
using System.Xml.Linq;
using HR.Business.Interfaces;
using HR.Business.Utilities.Exceptions;
using HR.Core.Entities;
using HR.DataAccess.Contexts;

namespace HR.Business.Services;

public class DepartmentService : IDepartmentService
{
    private ICompanyService companyservice { get; }
    public DepartmentService()
    {
        companyservice=new CompanyService();
    }
    public void AddEmployee(int? employeeId,int? departId)
    {
        if(employeeId is null)throw new ArgumentNullException();
        Employee? dbEmploye= HRDbContext.dbEmployees.Find(c => c.Id == employeeId);
        if(dbEmploye is null) throw new NotFoundException($"{employeeId} is not found");
        if (departId is null) throw new ArgumentNullException();
        Department? dbdepartment = HRDbContext.dbDepartments.Find(b => b.Id == departId);
        if (dbdepartment is null) throw new NotFoundException($"{departId} is not found");
        if (dbdepartment.CurrentEmployee < dbdepartment.EmployeeLimit)
        {
            if (dbEmploye.DepartmentId == null)
            {
                dbEmploye.DepartmentId = dbdepartment.Id;
                dbdepartment.CurrentEmployee++;
            }
            else
            {
                throw new AlreadyWorkOtherDepartment("This Employee already works in another Department");
            }
        }
        else
        {
            throw new MaxCapacityAxceeded("Maximum Employee capacity exceeded");
        }
    }

    public void Create(string? name,int? employeelimit,int companyid)
    {
        if (string.IsNullOrEmpty(name)) throw new ArgumentNullException();
        Department? dbdepartment=HRDbContext.dbDepartments.Find(c => c.Name.ToLower() == name.ToLower());
        if (dbdepartment?.CompanyId == companyid) throw new AlreadyExistException($"{name} already is exist");
        if (employeelimit is null) throw new ArgumentNullException();
        if (employeelimit > 6) throw new MaxCapacityAxceeded("Maximum capacity can be 6 employees");
        companyservice.FindCompanyWithId(companyid);
        Department department = new Department(name,companyid, employeelimit);
        HRDbContext.dbDepartments.Add(department);
        department.IsActivated = true;
    }
    
    public void Deactive(int? id)
    {
        if (id is null) throw new ArgumentNullException();
        Department? dbdepartment = HRDbContext.dbDepartments.Find(b => b.Id == id);
        if (dbdepartment is null) throw new NotFoundException($"{id} is not found");
        foreach (var employee in HRDbContext.dbEmployees)
        {
            if (dbdepartment.Id == employee.DepartmentId)
            {
                employee.DepartmentId = null;
            }
        }
        dbdepartment.IsActivated = false;
    }

    public void GetDepartmentEmployees(int? id)
    {
        if (id is null) throw new ArgumentNullException();
        Department? dbdepartment = HRDbContext.dbDepartments.Find(b => b.Id == id);
        if (dbdepartment is null) throw new NotFoundException($"{id} is not found");
        foreach (var employee in HRDbContext.dbEmployees)
        {
            if (dbdepartment.Id == employee.DepartmentId)
            {
                Console.WriteLine(employee);
            }
        }
    }

    public void ShowAll()
    {
        foreach (var department in HRDbContext.dbDepartments)
        {
            if (department.IsActivated == true)
            {
                Console.WriteLine(department);
            }
        }
    }

    public void UpdateDepartment(int? departId,string? newName, int employeeLimit)
    {
        if (departId is null) throw new ArgumentNullException();
        Department? dbdepartment = HRDbContext.dbDepartments.Find(b => b.Id == departId);
        if (dbdepartment is null) throw new NotFoundException($"{departId} is not found");
        if (string.IsNullOrEmpty(newName)) throw new ArgumentNullException();
        Department? dbNewDepartment = HRDbContext.dbDepartments.Find(b => b.Name.ToLower() == newName.ToLower());
        if (dbNewDepartment?.CompanyId == dbdepartment.CompanyId) throw new AlreadyExistException($"{newName} already is exist");
        dbdepartment.Name = newName;
        if (dbdepartment.CurrentEmployee < employeeLimit)
        {
            dbdepartment.EmployeeLimit = employeeLimit;
        }
        else
        {
            throw new CurrentEmployyeShouldntMore("Max employee should not be less than current employee.");
        }        
    }

    public void ShowDepartmentDetails(int? id)
    {
        if (id is null) throw new ArgumentNullException();
        Department? dbdepartment = HRDbContext.dbDepartments.Find(b => b.Id == id);
        if (dbdepartment is null) throw new NotFoundException($"{id} is not found");
        Console.WriteLine($"Department Id :{dbdepartment.Id}\n" +
                          $"Department Name :{dbdepartment.Name}\n" +
                          $"Current Employee count :{dbdepartment.CurrentEmployee}\n" +
                          $"Max Employee count :{dbdepartment.EmployeeLimit}");
    }
}

