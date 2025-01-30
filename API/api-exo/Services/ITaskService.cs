using apiExo.entity;

namespace apiExo.services;

public interface ITaskService {
    public ICollection<TaskEntity> GetAll();
    public TaskEntity? GetByID(int id);
    public string Add(TaskEntity task);
     public string Patch(TaskPatch task);
    public string Update(TaskUpdate task);

}