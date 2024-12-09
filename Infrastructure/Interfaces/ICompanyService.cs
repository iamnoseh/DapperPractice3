namespace Infrastructures;
using Domains;

public interface ICompanyService
{
    public void AddCompany(Company company);
    public void DeleteCompany(int id);
    public void UpdateCompany(Company company);
    public List<Company> GetAllCompanies();
}