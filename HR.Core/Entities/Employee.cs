using System;
using HR.Core.Interfaces;

namespace HR.Core.Entities;

public class Employee:IEntity
{
    public int Id { get; }
    private static int id;
    public string Name { get; set; }
    public string? Surname { get; set; }
    public int? Salary { get; set; }
    public int? DepartmentId { get; set; } = null;
    public bool IsActivate { get; set; } = false;
    public override string ToString()
    {
        return "Employee:" +"id : "+ Id + " | " +"name : "+ Name + " | " +"surname : "+ Surname+" | "+"salary : "+Salary+" | "+"Department ID : "+ DepartmentId;
    }
    public Employee(string name, string? surname, int? salary)
    {
        Name = name;
        Surname = surname;
        Salary = salary;
        Id = id++;
    }
}

