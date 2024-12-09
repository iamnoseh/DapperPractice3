namespace Infrastructures;
using Domains;

public interface IBranchService
{
    public void AddBranch(Branch branch);
    public void DeleteBranch(int id);
    public void UpdateBranch(Branch branch);
    public Branch GetBranch(int id);
    public List<Branch> GetAllBranches();
}