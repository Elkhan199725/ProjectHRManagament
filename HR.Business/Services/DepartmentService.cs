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

public class DepartmentService : IDepartmentService
{
    public IDepartmentService? departmentService { get; }
    public ICompanyService? companyService { get; }
    public DepartmentService()
    {
        companyService = new CompanyService();
    }
    public void Create(string? departmentName, string? departmentDescription, int companyId, int maxEmployeeLimitation)
    {
        if (String.IsNullOrEmpty(departmentName))
            throw new ArgumentNullException();
        if (companyId < 0)
            throw new MinRequirementException($"Id must be positive whole number!");
        Departments? dbDepartment =
            HRContextDB.Departments.Find(d => d.Name.ToLower() == departmentName.ToLower());
        Company? dbCompany =
            HRContextDB.Companies.Find(c => c.Id == companyId);
        if (dbCompany is null)
            throw new NotFoundException($"Company cannot be found");
        if (dbDepartment is not null && dbDepartment._companyId == dbCompany.Id)
            throw new AlreadyExistException($"{dbDepartment.Name.ToUpper()} Department is already exist");
        if (maxEmployeeLimitation < 4)
            throw new MinRequirementException($"The {departmentName.ToUpper()} department should have at least 4 employees ");
        Departments department = new(departmentName, departmentDescription, companyId, maxEmployeeLimitation);
        department._company = dbCompany;
        HRContextDB.Departments.Add(department);
        Console.WriteLine($"The new department- {department.Name.ToUpper()} has been successfully created.\n");

    }

    public void DeleteDepartment(int departmentId)
    {
        if (departmentId < 0)
            throw new MinRequirementException($"Id cannot be negative");

        Departments? dbDepartment =
            HRContextDB.Departments.Find(d => d.Id == departmentId);

        if (dbDepartment is not null)
        {
            bool hasEmployee = HRContextDB.Employees.Any(e => e._departmentId == dbDepartment.Id);
            if (hasEmployee)
                throw new NotFoundException($"Cannot delete Department as it has associated employees");
            else
            {
                HRContextDB.Departments.Remove(dbDepartment);
                Console.WriteLine($"Department has been successfully removed.");
            }
        }
        else
        {
            throw new NotFoundException($"Department cannot be found!");
        }
    }

    public void GetDepartmentEmployees(int departmentId)
    {
        if (departmentId < 0)
            throw new MinRequirementException($"Id cannot be negative");
        Departments? dbDepartment =
            HRContextDB.Departments.Find(d => d.Id == departmentId);
        if (dbDepartment is not null)
        {
            foreach (var employee in HRContextDB.Employees)
            {
                if (employee._departmentId == dbDepartment.Id)
                {
                    Console.WriteLine($"Employees:\n Id: {employee.Id}\n " +
                        $"Full Name: {employee.Name} {employee.Surname}\n " +
                        $"Position: {employee.Commission}\n " +
                        $"Salary: {employee.Wage}\n");
                }
            }
        }
        else throw new NotFoundException($"Department doesn't exist!");
    }

    public void EmployeeRelocation(int departmentId, int employeeId)
    {
        if (departmentId < 0)
            throw new MinRequirementException($"Id must be positive!");
        if (employeeId < 0)
            throw new ArgumentOutOfRangeException();

        Departments? dbDepartment = HRContextDB.Departments.Find(d => d.Id == departmentId);
        if (dbDepartment is null)
            throw new NotFoundException($"Department cannot be found");

        Employees? dbEmployee = HRContextDB.Employees.Find(e => e.Id == employeeId);
        if (dbEmployee is null)
            throw new NotFoundException($"Employee cannot be found");
        Departments? employeeDepartment = dbDepartment;
        foreach (var department in HRContextDB.Departments)
        {
            if (department.Id == dbEmployee._departmentId)
            {
                employeeDepartment = department;
                break;
            }
        }
        if (dbEmployee._departmentId != dbDepartment.Id && employeeDepartment._company.Name == dbDepartment._company.Name)
        {
            dbEmployee._department = dbDepartment;
            dbEmployee._departmentId = dbDepartment.Id;
            dbDepartment.CurrentEmployeeManpower++;
            Console.WriteLine($"The new employee - {dbEmployee.Name.ToUpper()} has been successfully added \n");
        }
        else if (dbEmployee._departmentId == dbDepartment.Id && employeeDepartment._company.Name == dbDepartment._company.Name)
        {
            throw new AlreadyExistException($"Employee {dbEmployee.Name.ToUpper()} is already in {dbDepartment.Name.ToUpper()} Department");
        }
        else throw new NotFoundException($"Employee cannot be found in company");
    }

    public void UpdateDepartment(string? newDepartmentName, string? newDescription, int newEmployeeLimit, int departmentId)
    {
        if (departmentId < 0)
            throw new MinRequirementException($"Id must be positive!");
        if (String.IsNullOrEmpty(newDepartmentName))
            throw new ArgumentNullException();
        Departments? dbDepartment =
          HRContextDB.Departments.Find(d => d.Id == departmentId);
        if (dbDepartment is null)
            throw new NotFoundException($"Department cannot be found");
        Departments? dbNewDepartment =
          HRContextDB.Departments.Find(d => d.Name.ToLower() == newDepartmentName.ToLower());
        if (dbNewDepartment is not null && dbNewDepartment._company == dbDepartment._company)
            throw new AlreadyExistException($"{newDepartmentName.ToUpper()} department is already exist");
        if (newEmployeeLimit < 4 || newEmployeeLimit < dbDepartment.CurrentEmployeeManpower)
            throw new MinRequirementException($"Employee count cannot be less than 3 or current employee count");
        dbDepartment.Name = newDepartmentName;
        dbDepartment.Description = newDescription;
        dbDepartment.MaxEmployeeLimitation = newEmployeeLimit;
        Console.WriteLine($"{newDepartmentName} Department has been successfully updated");
    }
}
