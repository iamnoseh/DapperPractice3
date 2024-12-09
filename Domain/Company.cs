namespace Domains;


public class Company
{
    public int Id { get; set; }          
    public string? Name { get; set; }     
    public DateTime FoundedYear { get; set; } 
    public string? Location { get; set; }  
    public int BranchId { get; set; } 
}