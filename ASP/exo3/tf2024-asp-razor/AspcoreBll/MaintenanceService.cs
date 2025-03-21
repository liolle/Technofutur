using tf2024_asp_razor.Database;
using tf2024_asp_razor.Models.Entities.Taxable;

namespace AspcoreBll;

class MaintenanceService : IRepository<MaintenanceEntity>
{

    private readonly IDataContext _context;

    public MaintenanceService(IDataContext context)
    {
        this._context = context;
    }

    public bool Delete(int Id)
    {
            MaintenanceEntity? entity = _context.Maintenances.SingleOrDefault(p => p.Id == Id);
        if (entity == null) { return false; }
        try
        {
            _context.Maintenances.Remove(entity);
            _context.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public IEnumerable<MaintenanceEntity> GetAll()
    {
        return _context.Maintenances.AsEnumerable();
    }

    public MaintenanceEntity? GetById(int Id)
    {
        return _context.Maintenances.SingleOrDefault(m=>m.Id==Id);
    }

    public bool Insert(MaintenanceEntity toInsert)
    {
        
        
        try
        {
            _context.Maintenances.Add(toInsert);
            _context.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool Update(MaintenanceEntity toUpdate)
    {
        try
        {
            //Attention à vérifier
            
            _context.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

}