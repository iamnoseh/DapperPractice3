namespace Infrastructures;
using Domains;
public interface IEmployeeService
{
    public void AddEmpoyee(Employee employee);
    public void DeleteEmployee(int id);
    public void UpdateEmployee(Employee employee);
    public Employee GetEmployeeById(int id);
    public List<Employee> GetEmployees();
}