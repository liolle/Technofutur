namespace apiExo.entity;

public class TaskEntity
{
    public int Id {get;set;}
    public required string Title {get;set;}
    public int CreatedAt {get;set;}
    public required string Status {get;set;}
}