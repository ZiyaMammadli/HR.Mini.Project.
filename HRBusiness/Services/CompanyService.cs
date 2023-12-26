using System;
using System.Xml.Linq;
using HR.Business.Interfaces;
using HR.Business.Utilities.Exceptions;
using HR.Core.Entities;
using HR.DataAccess.Contexts;

namespace HR.Business.Services;

public class CompanyService : ICompanyService
{
    public void Create(string? name)
    {
        if (string.IsNullOrEmpty(name)) throw new ArgumentNullException();
        Company? dbcompany =HRDbContext.dbCompanies.Find(b => b.Name.ToLower() == name.ToLower());
        if (dbcompany is not null) throw new AlreadyExistException($"{dbcompany} already is exist");
        Company company = new Company(name);
        HRDbContext.dbCompanies.Add(company);
        company.IsActivate = true;
    }

    public void Deactive(string? name)
    {
        if (string.IsNullOrEmpty(name)) throw new ArgumentNullException();
        Company? dbcompany = HRDbContext.dbCompanies.Find(b => b.Name.ToLower() == name.ToLower());
        if(dbcompany is null) throw new NotFoundException($"{name} is not found");
        foreach (var department in HRDbContext.dbDepartments)
        {
            if (dbcompany.Id == department.CompanyId)
            {
            DepartmentService departmentService= new DepartmentService();
            departmentService.Deactive(department.Id);
            }
        }
        dbcompany.IsActivate = false;

    }

    public void GetAllDepartment(string? name)
    {
        if (string.IsNullOrEmpty(name)) throw new ArgumentNullException();
        Company? dbcompany = HRDbContext.dbCompanies.Find(b => b.Name.ToLower() == name.ToLower());
        if (dbcompany is null) throw new NotFoundException($"{name} is not found");
        foreach (var department in HRDbContext.dbDepartments)
        {
            if (department.CompanyId == dbcompany.Id)
            {
                if (department.IsActivated == true)
                {
                    Console.WriteLine(department);
                }               
            }
        }
        
    }

    public void ShowAll()
    {
        foreach (var company in HRDbContext.dbCompanies)
        {
            if (company.IsActivate == true)
            {
               Console.WriteLine($"Company | Id : {company.Id} | Name : {company.Name} |");
            }
        }
    }

    public void FindCompanyWithId(int? id)
    {
        if (id is null) throw new ArgumentNullException();
        Company? dbcompany = HRDbContext.dbCompanies.Find(b => b.Id == id);
        if (dbcompany is null) throw new NotFoundException($"{dbcompany} is not found");
        Console.WriteLine($"Company | Id : {dbcompany.Id} | Name : {dbcompany.Name} |");
    }

   public void ShowAllCompanyId()
    {
        foreach (var company in HRDbContext.dbCompanies)
        {
            if (company.IsActivate == true)
            {
                Console.WriteLine($"|Company Id :{company.Id} |");
            }
        }
    }
}

