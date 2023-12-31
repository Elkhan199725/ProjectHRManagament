using BaseCore.HR.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace BaseCore.HR.Entities;

public class Departments : InterfaceID
{
    public int Id { get; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public int MaxEmployeeLimitation { get; set; }
    public Company _company { get; set; }
    public int _companyId { get; set; }
    static int id;
    public int CurrentEmployeeManpower;

    public Departments ( string name, string? description, int maxEmployeeLimitation,  int companyId)
    {
        Id = id;
        Name = name;
        Description = description;
        MaxEmployeeLimitation = maxEmployeeLimitation;
        _companyId = companyId;
        CurrentEmployeeManpower = default;
    }
    public override string ToString()
    {
        return $"Id: {id}; Name: {Name}; Company: {_company.Name} \n";
    }
}
