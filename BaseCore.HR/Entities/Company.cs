using BaseCore.HR.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BaseCore.HR.Entities;

public class Company : InterfaceID
{
    public int Id { get; }
    public string Name { get; set; }
    public string? Description { get; set; }
    private static int id;

    public Company (string name, string? description)
    {
        Id = id++;
        Name = name;
        Description = description;
    }
    public override string ToString()
    {
        return $"Id: {Id}; Name: {Name} \n";
    }
}

