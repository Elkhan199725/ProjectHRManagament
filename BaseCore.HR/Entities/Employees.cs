using BaseCore.HR.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCore.HR.Entities;

public class Employees : InterfaceID
{
    public int Id { get; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public Department? _department { get; set; }
    public int _departmentId { get; set; }
    public Company? Company { get; set; }
    public int Wage { get; set; }
    public string? Commission { get; set; } // job degree
    public bool IsDeleted { get; set; } = false;
    private static int id;

    public Employees(string name, string surname,int departmentId, int wage, string? commission)
    {
        Id = id;
        Name = name;
        Surname = surname;
        _departmentId = departmentId;
        Wage = wage;
        Commission = commission;
        IsDeleted = default(bool);
    }
    public override string ToString()
    {
        return $"Id: {Id}; Whole name: {String.Concat(Name, " ", Surname)} \n";
    }
}
