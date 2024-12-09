using Dapper;
using Domains;
using Dappercontext;
using Npgsql;

namespace Infrastructures;

public class DepartamentService:IDepartementService
{
    private readonly DapperContext context;

    public DepartamentService()
    {
        context = new DapperContext();
    }
    public void AddDepartament(Departament departament)
    {
        try
        {
            string cmd = @"INSERT Into Departaments (Name,Manager,Budget,EmployeeId) VALUES (@Name,@Manager,@Budget,@EmployeeId)";
            int effect = context.GetConnection().Execute(cmd, departament);
            if (effect != 0)
            {
                Console.WriteLine($"Departament {departament.Name} has been successfully added.");
            }
            else
            {
                Console.WriteLine($"Departament {departament.Name} has not been added.");
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void DelateDepartament(int id)
    {
        try
        {
            string cmd = @"DELETE FROM Departaments WHERE Id = @Id";
            int effect = context.GetConnection().Execute(cmd, new { Id = id });
            if (effect != 0)
            {
                Console.WriteLine($"Departament {id} has been successfully deleted.");
            }
            else
            {
                Console.WriteLine($"Departament {id} has not been deleted.");
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        };
    }

    public void UpdateDepartament(Departament departament)
    {
        try
        {
            string cmd = "Updeate Departaments set Name = @name,Manager = @Manager,Budget = @Budget,eEmployeeId = @EmployeeId WHERE Id = @Id";
            int eff = context.GetConnection().Execute(cmd, departament);
            if (eff != 0)
            {
                Console.WriteLine($"Departament {departament.Name} has been successfully updated.");
            }
            else
            {
                Console.WriteLine($"Departament {departament.Name} has not been updated.");
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Departament GetDepartamentById(int id)
    {
        try
        {
            string cmd = @"SELECT * FROM Departaments WHERE Id = @Id";
            Console.WriteLine("|||||||||||||||  Departament!  ||||||||||||||||||");
            return context.GetConnection().Query<Departament>(cmd, new { Id = id }).FirstOrDefault();

        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public List<Departament> GetDepartaments()
    {
        try
        {
            string cmd = @"SELECT * FROM Departaments";
            Console.WriteLine("||||||||||||  Departaments!  ||||||||||||||");
            List<Departament> departaments = context.GetConnection().Query<Departament>(cmd).ToList();
            return departaments;
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}