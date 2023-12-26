using System;
using HR.Core.Interfaces;

namespace HR.Core.Entities;

public class Company : IEntity
{
    public int Id { get; }
    private static int id;
    public string Name { get; set; }
    public bool IsActivate { get; set; } = false;
    public Company(string name)
    {
        Name = name;
        Id = id++;
    }
}

