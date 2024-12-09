namespace Infrastructures;
using Domains;


public interface IDepartementService
{
    public void AddDepartament(Departament departament);
    public void DelateDepartament(int id);
    public void UpdateDepartament(Departament departament);
    public Departament GetDepartamentById(int id);
    public List<Departament> GetDepartaments();
}