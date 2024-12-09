using Dapper;
using Domains;
using Npgsql;
using Dappercontext;

namespace Infrastructures;

public class BranchService:IBranchService
{
     readonly DapperContext context;

    public BranchService()
    {
        context = new DapperContext();
    }
    public void AddBranch(Branch branch)
    {
        string cmd = @"INSERT INTO branches(Name,Address,Phone,EmployeeId) VALUES(@Name,@Address,@Phone,@EmployeeId)";
        int effect = context.GetConnection().Execute(cmd, branch);
        if (effect != 0)
        {
            Console.WriteLine("Branch is  added");
        }
        else
        {
            Console.WriteLine("Branch is  NOT added");
        }
    }

    public void DeleteBranch(int id)
    {
        string cmd = @"DELETE FROM branches WHERE Id = @Id";
        int effect = context.GetConnection().Execute(cmd, new { Id = id });
        if (effect != 0)
        {
            Console.WriteLine("Branch is  deleted");
        }
        else
        {
            Console.WriteLine("Branch is  NOT deleted");
        }
    }

    public void UpdateBranch(Branch branch)
    {
        string cmd = "Update branches set Name = @name, Address = @address, Phone = @phone, EmployeeId = @employeeId where Id = @Id";
        int effect = context.GetConnection().Execute(cmd, branch);
        if (effect != 0)
        {
            Console.WriteLine("Branch is  updated ");
        }
        else
        {
            Console.WriteLine("Branch is  NOT updated");
        }
    }

    public Branch GetBranch(int id)
    {
        string cmd = @"SELECT * FROM branches WHERE Id = @Id";
        Console.WriteLine("||||||||||||||||||| Branch |||||||||||||||||||");
        return context.GetConnection().Query<Branch>(cmd, new { Id = id }).FirstOrDefault();
    }

    public List<Branch> GetAllBranches()
    {
        string cmd = @"SELECT * FROM branches";
        Console.WriteLine("|||||||||||||||||||| Branches ||||||||||||||||");
        List<Branch> branches = context.GetConnection().Query<Branch>(cmd).ToList();
        return branches;
    }
}