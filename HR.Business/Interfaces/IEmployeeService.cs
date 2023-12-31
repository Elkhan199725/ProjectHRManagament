using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Business.Interfaces;

public interface IEmployeeService
{
    void Create(string? employeeName, string? employeeSurname, int employeeSalary, int departmentId, string? position);
    void UpdateSalary(int employeeId, int departmentId, int newSalary);
    void UpdatePosition(int employeeId, string newPosition);
    void DeleteEmployee(int employeeId);
}
