using BaseCore.HR.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Business.Interfaces;

public interface ICompanyService
{
    void Create(string? companyName, string companyDescription);
    void GetAllDepartments(string? companyName);
    void GetAllEmployees(string? companyName);
    Company? FindCompanyByName(string? companyName);
    void UpdateCompany(string? companyName, string? newCompanyName, string? newDescription);
    void ShowAllCompanies();
    void DeleteCompany(string? companyName);
}
