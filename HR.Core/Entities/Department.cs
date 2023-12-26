using System;
using HR.Core.Interfaces;

namespace HR.Core.Entities;

public class Department : IEntity
{
    public int Id { get; }
    private static int id;
    public string Name { get; set; }
    public int? EmployeeLimit { get; set; }
    public int CompanyId { get; set; }
    public bool IsActivated { get; set; } = false;
    public int CurrentEmployee { get; set; } = 0;
    public override string ToString()
    {
        return "Department:" +"ID : "+ Id +" | "+"NAME : " + Name;
    }
    public Department(string name,int companyid,int? employeelimit)
    {
        Name = name;
        Id = id++;
        CompanyId = companyid;
        EmployeeLimit = employeelimit;
    }
}

