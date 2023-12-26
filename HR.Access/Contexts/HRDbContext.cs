using System;
using HR.Core.Entities;

namespace HR.DataAccess.Contexts;

public static class HRDbContext
{
    public static List<Company> dbCompanies { get; set; } = new List<Company>();
    public static List<Department> dbDepartments { get; set; } = new List<Department>();
    public static List<Employee> dbEmployees { get; set; } = new List<Employee>();
}

