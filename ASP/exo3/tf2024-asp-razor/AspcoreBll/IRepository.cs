namespace AspcoreBll;
public interface IRepository<T>
{
    bool Insert(T toInsert);
    bool Update(T toUpdate);
    bool Delete(int Id);

    T? GetById(int Id);
    IEnumerable<T> GetAll();
}
