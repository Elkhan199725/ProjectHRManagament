using DataAccessHR.Context;
using HR.Business.Services;

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Welcome!");
Console.ResetColor();
bool isContinue = true;
while (isContinue)
{
    CompanyService companyService = new();
    DepartmentService departmentService = new();
    EmployeeService employeeService = new();
    Console.WriteLine("--------------------------------------");
    Console.ForegroundColor = ConsoleColor.DarkBlue;
    Console.WriteLine("Company: \n");
    Console.ResetColor();
    Console.WriteLine("1)Create Company");
    Console.WriteLine("2)Get all Departments In Company");
    Console.WriteLine("3)Get all Employees In Company");
    Console.WriteLine("4)Update Company");
    Console.WriteLine("5)Show all Companies");
    Console.WriteLine("6)Remove Company\n");
    Console.WriteLine("--------------------------------------");
    Console.ForegroundColor = ConsoleColor.DarkBlue;
    Console.WriteLine("Department: \n");
    Console.ResetColor();
    Console.WriteLine("7)Create Department");
    Console.WriteLine("8)Relocate Employee to Department");
    Console.WriteLine("9)Update Department");
    Console.WriteLine("10)Get Department Employee ");
    Console.WriteLine("11)Remove Department \n");
    Console.WriteLine("--------------------------------------");
    Console.ForegroundColor = ConsoleColor.DarkBlue;
    Console.WriteLine("Employee: \n");
    Console.ResetColor();
    Console.WriteLine("12)Create Employee");
    Console.WriteLine("13)Update The Wage Of An Employee");
    Console.WriteLine("14)Update The Commission Of An Employee");
    Console.WriteLine("15)Remove Employee");
    Console.WriteLine("--------------------------------------");
    Console.WriteLine("0)Exit");
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine("\n Select one of the options >>\n");
    Console.ResetColor();
    string? option = Console.ReadLine();
    int intOption;
    bool isInt = int.TryParse(option, out intOption);
    if (isInt)
    {
        if (intOption >= 0 && intOption <= 15)
        {
            switch (intOption)
            {
                case (int)ConsoleApp.CreateCompany:
                    try
                    {
                        Console.WriteLine("Enter Company Name:");
                        string? companyName = Console.ReadLine();
                        Console.WriteLine("Enter Company Description:");
                        string? companyDescription = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        companyService.Create(companyName, companyDescription);
                        Console.ResetColor();
                    }
                    catch (Exception exception)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(exception.Message);
                        Console.ResetColor();
                    }
                    break;
                case (int)ConsoleApp.GetAllDepartments:
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("Companies:\n");
                        foreach (var company in HRContextDB.Companies)
                        {
                            Console.WriteLine(company.Name);
                        }
                        Console.ResetColor();
                        Console.WriteLine("\n Enter Company Name: \n");
                        string? companyName = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        companyService.GetAllDepartments(companyName);
                        Console.ResetColor();
                    }
                    catch (Exception exception)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(exception.Message);
                        Console.ResetColor();
                    }
                    break;
                case (int)ConsoleApp.GetAllEmployees:
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("Companies: \n");
                        foreach (var company in HRContextDB.Companies)
                        {
                            Console.WriteLine(company.Name);
                        }
                        Console.ResetColor();
                        Console.WriteLine("\n Enter Company Name: \n");
                        string? companyName = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        companyService.GetAllEmployees(companyName);
                        Console.ResetColor();
                    }
                    catch (Exception exception)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(exception.Message);
                        Console.ResetColor();
                    }
                    break;
                case (int)ConsoleApp.UpdateCompany:
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Companies:\n");
                        foreach (var company in HRContextDB.Companies)
                        {
                            Console.WriteLine($"{company.Name} \n");
                        }
                        Console.ResetColor();

                        Console.WriteLine("Enter Company Name:");
                        string? companyName = Console.ReadLine();
                        Console.WriteLine("Enter New Name For Company:");
                        string? newCompanyName = Console.ReadLine();
                        Console.WriteLine("Enter New Description For Company:");
                        string? newDescription = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        companyService.UpdateCompany(companyName, newCompanyName, newDescription);
                        Console.ResetColor();
                    }
                    catch (Exception exception)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(exception.Message);
                        Console.ResetColor();
                    }
                    break;
                case (int)ConsoleApp.ShowAllCompanies:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    companyService.ShowAllCompanies();
                    Console.ResetColor();
                    break;
                case (int)ConsoleApp.DeleteCompany:
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Companies: \n");
                        foreach (var company in HRContextDB.Companies)
                        {
                            Console.WriteLine($"{company.Name}");
                        }
                        Console.ResetColor();
                        Console.WriteLine("Enter Company Name: ");
                        string? companyName = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        companyService.DeleteCompany(companyName);
                        Console.ResetColor();
                    }
                    catch (Exception exception)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(exception.Message);
                        Console.ResetColor();
                    }
                    break;
                case (int)ConsoleApp.CreateDepartment:
                    try
                    {
                        Console.WriteLine("Enter Department Name:");
                        string? departmentName = Console.ReadLine();
                        Console.WriteLine("Enter Department Description:");
                        string? departmentDescription = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("Companies:\n");
                        foreach (var company in HRContextDB.Companies)
                        {
                            Console.WriteLine($"Id: {company.Id}\n Name: {company.Name} \n");
                        }
                        Console.ResetColor();
                        Console.WriteLine("Enter Company Id: \n");
                        int _companyId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Employee Limit");
                        int maxEmployee = Convert.ToInt32(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.Green;
                        departmentService.Create(departmentName, departmentDescription, _companyId, maxEmployee);
                        Console.ResetColor();
                    }
                    catch (Exception exception)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(exception.Message);
                        Console.ResetColor();
                    }
                    break;
                case (int)ConsoleApp.EmployeeRelocation:
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        foreach (var employee in HRContextDB.Employees)
                        {
                            Console.WriteLine($"Id:{employee.Id}/Full Name: {employee.Name } {employee.Surname} ");
                        }
                        Console.ResetColor();
                        Console.WriteLine("Enter Employee Id:\n");
                        int employeeId = Convert.ToInt32(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        foreach (var department in HRContextDB.Departments)
                        {
                            Console.WriteLine($"Departments:\n Id: {department.Id}\n " +
                                $"Name: {department.Name} \n " +
                                $"Company:{department._company.Name}\n \n");
                        }
                        Console.ResetColor();
                        Console.WriteLine("Enter New Department Id:");
                        int departmentId = Convert.ToInt32(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.Green;
                        departmentService.EmployeeRelocation(departmentId, employeeId);
                        Console.ResetColor();

                    }
                    catch (Exception exception)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(exception.Message);
                        Console.ResetColor();
                    }
                    break;
                case (int)ConsoleApp.UpdateDepartment:
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;

                        Console.WriteLine("Departments:\n");
                        foreach (var department in HRContextDB.Departments)
                        {
                            Console.WriteLine($"Id: {department.Id}\n " +
                                $"Name: {department.Name} \n " +
                                $"Company:{department._company.Name}\n \n");
                        }
                        Console.ResetColor();

                        Console.WriteLine("Enter Department Id:");
                        int departmentId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter New Name For Department:");
                        string? newDepartmentName = Console.ReadLine();
                        Console.WriteLine("Enter New Description For Department:");
                        string? newDescription = Console.ReadLine();
                        Console.WriteLine($"Enter New Employee Limit:");
                        int newEmployeeLimit = Convert.ToInt32(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.Green;
                        departmentService.UpdateDepartment(newDepartmentName, newDescription, newEmployeeLimit, departmentId);
                        Console.ResetColor();
                    }
                    catch (Exception exception)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(exception.Message);
                        Console.ResetColor();
                    }
                    break;
                case (int)ConsoleApp.GetDepartmentEmployees:
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        foreach (var department in HRContextDB.Departments)
                        {
                            Console.WriteLine($"Departments:\n " +
                                $"Id: {department.Id}\n " +
                                $"Name: {department.Name}  \n " +
                                $"Company: {department._company.Name}\n \n");
                        }
                        Console.ResetColor();
                        Console.WriteLine("Enter Department Id:");
                        int departmentId = Convert.ToInt32(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.Green;
                        departmentService.GetDepartmentEmployees(departmentId);
                        Console.ResetColor();
                    }
                    catch (Exception exception)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(exception.Message);
                        Console.ResetColor();
                    }
                    break;
                case (int)ConsoleApp.DeleteDepartment:
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        foreach (var department in HRContextDB.Departments)
                        {
                            Console.WriteLine($"Departments:\n " +
                                $"Id: {department.Id}\n " +
                                $"Name: {department.Name}  \n " +
                                $"Company: {department._company.Name}\n \n");
                        }
                        Console.ResetColor();
                        Console.WriteLine("Enter Department Id:");
                        int departmentId = Convert.ToInt32(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.Green;
                        departmentService.DeleteDepartment(departmentId);
                        Console.ResetColor();
                    }
                    catch (Exception exception)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(exception.Message);
                        Console.ResetColor();
                    }
                    break;

                case (int)ConsoleApp.CreateEmployee:
                    try
                    {
                        Console.WriteLine("Enter Employee Name:");
                        string? employeeName = Console.ReadLine();
                        Console.WriteLine("Enter Employee Surname:");
                        string? employeeSurname = Console.ReadLine();
                        Console.WriteLine("Enter Employee Wage:");
                        int employeeWage = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Employee Position:");
                        string? employeeCommission = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        foreach (var department in HRContextDB.Departments)
                        {
                            Console.WriteLine($"Departments:\n " +
                                $"Id: {department.Id}\n " +
                                $"Name: {department.Name}  \n " +
                                $"Company: {department._company.Name}\n \n");
                        }
                        Console.ResetColor();
                        Console.WriteLine("Enter Department Id:\n");
                        int employeeDepartmentId = Convert.ToInt32(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.Green;
                        employeeService.Create(employeeName, employeeSurname, employeeWage, employeeDepartmentId, employeeCommission);
                        Console.ResetColor();
                    }
                    catch (Exception exception)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(exception.Message);
                        Console.ResetColor();
                    }
                    break;
                case (int)ConsoleApp.UpdateWage:
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"Departments:");
                        foreach (var department in HRContextDB.Departments)
                        {
                            Console.WriteLine($"Id: {department.Id}\n " +
                                $"Name: {department.Name}  \n " +
                                $"Company: {department._company.Name}\n \n");
                        }
                        Console.ResetColor();

                        Console.WriteLine("Enter Department Id:");

                        int departmentId = Convert.ToInt32(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        departmentService.GetDepartmentEmployees(departmentId);
                        Console.ResetColor();
                        Console.WriteLine("Enter Employee Id:");
                        int employeeId = Convert.ToInt32(Console.ReadLine());
                        Console.ResetColor();
                        Console.WriteLine("Enter New Wage:");
                        int newWage = Convert.ToInt32(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.Green;
                        employeeService.UpdateWage(newWage, employeeId, departmentId);
                        Console.ResetColor();
                    }
                    catch (Exception exception)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(exception.Message);
                        Console.ResetColor();
                    }
                    break;
                case (int)ConsoleApp.UpdateCommission:
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("Employees:\n");
                        foreach (var employee in HRContextDB.Employees)
                        {
                            Console.WriteLine($"Id:{employee.Id}/ Full Name:{employee.Name} {employee.Surname}\n" +
                                $"Company:{employee.Company.Name}/ Department:{employee._department.Name}/ Commission:{employee.Commission}\n\n");
                        }
                        Console.ResetColor();
                        Console.WriteLine("Enter Employee Id:");
                        int employeeId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter new Commission:");
                        string? newCommission = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        employeeService.UpdateCommission(employeeId, newCommission);
                        Console.ResetColor();
                    }
                    catch (Exception exception)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(exception.Message);
                        Console.ResetColor();
                    }
                    break;
                case (int)ConsoleApp.DeleteEmployee:
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        foreach (var employee in HRContextDB.Employees)
                        {
                            Console.WriteLine($"Id:{employee.Id}/Full Name: {employee.Name} {employee.Surname}\n" +
                                              $"Position: {employee.Commission}\n \n");
                        }
                        Console.ResetColor();
                        Console.WriteLine("Enter Employee Id:");
                        int employeeId = Convert.ToInt32(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.Green;
                        employeeService.DeleteEmployee(employeeId);
                        Console.ResetColor();
                    }
                    catch (Exception exception)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(exception.Message);
                        Console.ResetColor();
                    }
                    break;

                default:
                    isContinue = false;
                    break;
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enter correct option number!");
            Console.ResetColor();
        }
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Enter correct format! \n");
        Console.ResetColor();
    }
}