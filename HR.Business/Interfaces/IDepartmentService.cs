using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Business.Interfaces;

public interface IDepartmentService
{
    void Create(string? departmentName, string departmentDescription, int companyId, int employeeLimit);
    void EmployeeRelocation(int departmentId, int employeeId);
    void UpdateDepartment(string? newDepartmentName, string? newDescription, int newEmployeeLimit, int departmentId);
    void GetDepartmentEmployees(int departmentId);
    void DeleteDepartment(int departmentId);
}