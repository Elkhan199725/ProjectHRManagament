using BaseCore.HR.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessHR.Context;

public class HRContextDB
{
    public static List<Company> Companies { get; set; } = new List<Company>();
    public static List<Departments> Departments { get; set; } = new List<Departments>();
    public static List<Employees> Employees { get; set; } = new List<Employees>();
}
