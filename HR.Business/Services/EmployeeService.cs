using BaseCore.HR.Entities;
using DataAccessHR.Context;
using HR.Business.Interfaces;
using HR.Business.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Business.Services;

public class EmployeeService : IEmployeeService
{
    public IDepartmentService departmentService { get; }
    public IEmployeeService employeeService { get; }
    public EmployeeService()
    {
        departmentService = new DepartmentService();
    }

    public void Create(string? employeeName, string? employeeSurname, int employeeWage, int departmentId, string? commission)
    {
        if (String.IsNullOrEmpty(employeeName))
            throw new ArgumentNullException();
        if (String.IsNullOrEmpty(employeeSurname))
            throw new ArgumentNullException();
        if (String.IsNullOrEmpty(commission))
            throw new ArgumentNullException();

        if (employeeWage <= 0)
            throw new MinRequirementException($"Wage must be positive");
        if (departmentId < 0)
            throw new MinRequirementException($"Id must be positive whole number!");

        Departments? dbDepartment = HRContextDB.Departments.Find(d => d.Id == departmentId);
        if (dbDepartment is null)
            throw new NotFoundException($"Department cannot be found");
        if (dbDepartment.CurrentEmployeeManpower == dbDepartment.MaxEmployeeLimitation)
            throw new AlreadyFullException($"{dbDepartment.Name} Department is already full");
        Employees employee = new Employees(employeeName, employeeSurname, departmentId, employeeWage, commission);
        employee._department = dbDepartment;
        employee.Company = dbDepartment._company;
        HRContextDB.Employees.Add(employee);
        dbDepartment.CurrentEmployeeManpower++;
        Console.WriteLine($"The new employee {employee.Name} has been successfully created \n");
    }

    public void DeleteEmployee(int employeeId)
    {
        if (employeeId < 0)
            throw new MinRequirementException("Id must be positive whole number!");

        Employees? dbEmployee =
            HRContextDB.Employees.Find(e => e.Id == employeeId);

        if (dbEmployee is not null)
        {
            HRContextDB.Employees.Remove(dbEmployee);
            Console.WriteLine($"Employee has been successfully removed!");

        }
        else
        {
            throw new NotFoundException($"Employee does not exist.");
        }
    }

    public void UpdateCommission(int employeeId, string newCommission)
    {
        if (employeeId < 0)
            throw new MinRequirementException($"Id must be positive whole number!");
        if (String.IsNullOrEmpty(newCommission))
            throw new ArgumentNullException();
        Employees? employee =
           HRContextDB.Employees.Find(e => e.Id == employeeId);
        if (employee is null)
            throw new NotFoundException("Employee does not exist.");
        if (newCommission == employee.Commission)
            throw new AlreadyExistException($"Employee's position is already {newCommission}");
        employee.Commission = newCommission;
        Console.WriteLine("Position of employee is updated successfully");
    }

    public void UpdateWage(int employeeId, int departmentId, int newWage)
    {
        if (departmentId < 0)
            throw new MinRequirementException($"Id must be positive!");
        if (employeeId < 0)
            throw new MinRequirementException($"Id must be positive!");
        if (newWage <= 0)
            throw new MinRequirementException($"Salary must be positive number!");
        Departments? department = HRContextDB.Departments.Find(d => d.Id == departmentId);
        if (department is null)
            throw new NotFoundException("Department does not exist.");
        Employees? employee =
            HRContextDB.Employees.Find(e => e.Id == employeeId);
        if (employee is null)
            throw new NotFoundException("Employee does not exist.");
        if (employee.Company == department._company)
        {
            employee.Wage = newWage;
            Console.WriteLine("Wage has been successfully updated!");
        }
        else
            throw new NotFoundException($"Employee does not exist in Company! ");
    }
}
