
using AspcoreBll;
using AspInterfaces;
using tf2024_asp_razor.Models.Entities;

public class PlaneTypeService : IPlaneTypeService
{
      private readonly IDataContext _context;

    public PlaneTypeService(IDataContext context)
    {
        this._context = context;
    }
    public bool Delete(int Id)
    {
        PlaneTypeEntity? entity = _context.Types.SingleOrDefault(p => p.Id == Id);
        if (entity == null) { return false; }
        try
        {
            _context.Types.Remove(entity);
            _context.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public IEnumerable<PlaneTypeEntity> GetAll()
    {
        return _context.Types.AsEnumerable();
    }

    public PlaneTypeEntity? GetById(int Id)
    {
        return _context.Types.SingleOrDefault(m=>m.Id==Id);
    }

    public bool Insert(PlaneTypeEntity toInsert)
    {
        try
        {
            _context.Types.Add(toInsert);
            _context.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool Update(PlaneTypeEntity toUpdate)
    {
        throw new NotImplementedException();
    }
}