using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Business.Interfaces;

public interface IEmployeeService
{
    void Create(string? employeeName, string? employeeSurname, int employeeWage, int departmentId, string? position);
    void UpdateWage(int employeeId, int departmentId, int newWage);
    void UpdateCommission(int employeeId, string newPosition);
    void DeleteEmployee(int employeeId);
}
