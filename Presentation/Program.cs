using Domains;
using Infrastructures;



CompanyService companyService = new CompanyService();
// companyService.AddCompany(new Company()
// {
//     Name = "Shirkati 12",
//     Location = "Dushanbe",
//     FoundedYear = Convert.ToDateTime("2024-12-12"),
//     BranchId = 1
// });

companyService.GetAllCompanies();
List<Company> companies = companyService.GetAllCompanies();
foreach (var c in companies)
{
    Console.WriteLine("ID: " + c.Id + " || "+"Name: " + c.Name+" || "+ "Location: " + c.Location +" || "+ "FoundedYear: " + c.FoundedYear +" || " + " BranchID: " + c.BranchId );
}

Console.ReadLine();

// Company company = new Company();
// company.Id = 2;
// company.Location = "New Location";
// company.FoundedYear = DateTime.Parse("1900-12-12");
// company.BranchId = 1;
// company.Name = "New Company";
// companyService.UpdateCompany(company);

companyService.DeleteCompany(4);

EmployeeService employeeService = new EmployeeService();

List<Employee> employees = employeeService.GetEmployees();
employees = employeeService.GetEmployees();
foreach (var e in employees)
{
    Console.WriteLine("ID: " + e.Id + " || " + "Name: " + e.Name + " || " + "Age: " + e.Id + "Position: " + e.Position);
}