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

public class CompanyService : ICompanyService
{
    public void Create(string? companyName, string companyDescription)
    {
        if (String.IsNullOrEmpty(companyName)) throw new ArgumentNullException();
        Company? dbCompany =
            HRContextDB.Companies.Find(c => c.Name.ToLower() == companyName.ToLower());
        if (dbCompany != null) throw new AlreadyExistException($"{dbCompany.Name} is already exist.");
        Company company = new Company(companyName, companyDescription);
        HRContextDB.Companies.Add(company);
        Console.WriteLine($"{company.Name} created successfully.");
    }

    public void DeleteCompany(string? companyName)
    {
        if (String.IsNullOrEmpty (companyName)) throw new ArgumentNullException();
        Company? dbCompany =
            HRContextDB.Companies.Find(c => c.Name.ToLower() == companyName.ToLower());
        if (dbCompany is not null)
        {
            bool hasDepartments = HRContextDB.Departments.Any(d => d._company.Name.ToLower() == dbCompany.Name.ToLower());
            if (hasDepartments)
            {
                throw new NotFoundException($"It is not possible to delete {companyName} 'company' due it has association with department!");
            }
            else
            {
                HRContextDB.Companies.Remove(dbCompany);
                Console.WriteLine($"{companyName} 'company' has been successfully removed!");
            }          
        }
        else
        {
            throw new NotFoundException($"{companyName} 'company' doesn't exist.");
        }
    }

    public Company? FindCompanyByName(string? companyName)
    {
        if (String.IsNullOrEmpty(companyName))
            throw new ArgumentNullException();
        return HRContextDB.Companies.Find(c => c.Name.ToLower() == companyName.ToLower());
    }

    public void GetAllDepartments(string? companyName)
    {
        int counter = 0;
        if (String.IsNullOrEmpty(companyName))
            throw new ArgumentNullException();
        Company? dbCompany =
            HRContextDB.Companies.Find(c => c.Name.ToLower() == companyName.ToLower());
        if (dbCompany is not null)
        {
            Console.WriteLine($"Departments in {companyName} Company:");
            foreach (var department in HRContextDB.Departments)
            {
                if (department._company.Name.ToLower() == dbCompany.Name.ToLower())
                {
                    counter++;
                    Console.WriteLine($"{department.Id}){department.Name} Department\n" +
                        $"Employee Limit:{department.MaxEmployeeLimitation}/ Current Employee Count:{department.CurrentEmployeeManpower}");
                }
            }
            if (counter == 0) Console.WriteLine($"{companyName} company does not have any department");
        }
        else throw new NotFoundException($"{companyName} Company cannot be found");
    }

    public void GetAllEmployees(string? companyName)
    {
        int counter = 0;
        if (String.IsNullOrEmpty(companyName))
            throw new ArgumentNullException();
        Company? dbCompany =
            HRContextDB.Companies.Find(c => c.Name.ToLower() == companyName.ToLower());
        if (dbCompany is not null)
        {
            Console.WriteLine($"Employees in {companyName.ToUpper()} Company:\n");
            foreach (var employee in HRContextDB.Employees)
            {
                if (employee.Company.Name.ToLower() == dbCompany.Name.ToLower())
                {
                    counter++;
                    Console.WriteLine($"Id:{employee.Id}/Full Name:{employee.Name} {employee.Surname}\n" +
                        $"Department:{employee._department.Name}/ Position:{employee.Commission}");
                }
            }
            if (counter == 0) Console.WriteLine($"{companyName} company does not have any department");
        }
        else throw new NotFoundException($"{companyName.ToUpper()} Company cannot be found");
    }

    public void ShowAllCompanies()
    {
        foreach (var company in HRContextDB.Companies)
        {
            Console.WriteLine($"{company.Id}) {company.Name.ToUpper()}");
        }
    }

    public void UpdateCompany(string? companyName, string? newCompanyName, string? newDescription)
    {
        if (String.IsNullOrEmpty(companyName))
            throw new ArgumentNullException();
        if (String.IsNullOrEmpty(newCompanyName))
            throw new ArgumentNullException();
        Company? dbCompany =
            HRContextDB.Companies.Find(c => c.Name.ToLower() == companyName.ToLower());
        if (dbCompany is null)
            throw new NotFoundException($"Company doesn't exist.");
        Company? dbNewCompany =
            HRContextDB.Companies.Find(c => c.Name.ToLower() == newCompanyName.ToLower());
        if (dbNewCompany != null)
            throw new AlreadyExistException($"{newCompanyName.ToUpper()} Company is already exist");
        dbCompany.Name = newCompanyName;
        dbCompany.Description = newDescription;
        Console.WriteLine($"{newCompanyName.ToUpper()} Company has been successfully updated");
    }
}
