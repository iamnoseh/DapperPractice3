using System.Threading.Channels;
using Dapper;
using Domains;
using Dappercontext;
namespace Infrastructures;

public class CompanyService:ICompanyService
{
    private readonly DapperContext context;

    public CompanyService()
    {
        context = new DapperContext();
    }
    public void AddCompany(Company company)
    {
        string cmd = "Insert into Companyes (Name,FoundedYear,Location,BranchId) values (@Name,@FoundedYear,@Location,@BranchId)";
        int effect = context.GetConnection().Execute(cmd, company);
        if (effect != 0)
        {
            Console.WriteLine("New Company added");
        }
        else
        {
            Console.WriteLine(" No Company added");
        }
    }

    public void DeleteCompany(int id)
    {
        string cmd = "Delete From Companyes where id=@Id";
        int effect = context.GetConnection().Execute(cmd, new { id = @id});
        if (effect != 0)
        {
            Console.WriteLine(" Company deleted");
        }
        else
        {
            Console.WriteLine(" No Company deleted");
        }
    }

    public void UpdateCompany(Company company)
    {
        string cmd = "Update Companyes set Name = @Name,FoundedYear = @FoundedYear,Location = @Location,BranchId = @BranchId where Id=@Id";
        int effect = context.GetConnection().Execute(cmd,company);
        if (effect != 0)
        {
            Console.WriteLine("Company updated");
        }
        else
        {
            Console.WriteLine(" No Company updated");
        }
    }

    public List<Company> GetAllCompanies()
    {
        string cmd = "Select * From Companyes";
        Console.WriteLine("||||||||||||||||||| Companies ||||||||||||||||");
        List<Company> companies = new List<Company>();
        companies = context.GetConnection().Query<Company>(cmd).ToList();
        return companies;
    }
}