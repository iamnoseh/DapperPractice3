using Domains;
using Dappercontext;
using Dapper;
using Npgsql;

namespace Infrastructures;

public class EmployeeService:IEmployeeService
{
    private readonly DapperContext context;

    public EmployeeService()
    {
        context = new DapperContext();
    }
    public void AddEmpoyee(Employee employee)
    {
        try
        {
            string cmd = "Insert into employees (Name,Age,Position,Salary) values (@Name,@Age,@Position,@Salary);";
            int effect = context.GetConnection().Execute(cmd, employee);
            if (effect != 0)
            {
                Console.WriteLine("Employee " + employee.Name + " is added.");
            }
            else
            {
                Console.WriteLine("Employee " + employee.Name + " is not added.");
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void DeleteEmployee(int id)
    {
        try
        {
            string cmd = "Delete from employees where id = @Id;";
            int effect = context.GetConnection().Execute(cmd, new { Id = id });
            if (effect != 0)
            {
                Console.WriteLine("Employee " + id + " is deleted.");
            }
            else
            {
                Console.WriteLine("Employee " + id + " is not deleted.");
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void UpdateEmployee(Employee employee)
    {
        try
        {
            string cmd = "Update employees set Name = @Name,Age = @Age,Position = @Position,Salary = @Salary where id = @Id;";
            int effect = context.GetConnection().Execute(cmd, employee);
            if (effect != 0)
            {
                Console.WriteLine("Employee " + employee.Name + " is updated.");
            }
            else
            {
                Console.WriteLine("Employee " + employee.Name + " is not updated.");
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Employee GetEmployeeById(int id)
    {
        try
        {
            string cmd = "select * from employees where id = @Id;";
            Console.WriteLine("|||||||||||||||  Employee  |||||||||||||||||||||||");
            Employee employee = context.GetConnection().Query<Employee>(cmd, new { Id = id }).FirstOrDefault();
            return employee;
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public List<Employee> GetEmployees()
    {
        try
        {
            string cmd = "select * from employees";
            List<Employee> employees = context.GetConnection().Query<Employee>(cmd).ToList();
            Console.WriteLine("||||||||||||||||   Employees   |||||||||||||||||||");
            return employees;
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}