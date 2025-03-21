using tf2024_asp_razor.Database;
using tf2024_asp_razor.Models.Entities.Taxable;

namespace AspcoreBll;

class PilotService : IRepository<PilotEntity>
{

    private readonly IDataContext _context;

    public PilotService(IDataContext context)
    {
        this._context = context;
    }

    public bool Delete(int Id)
    {
            PilotEntity? entity = _context.Pilots.SingleOrDefault(p => p.Id == Id);
        if (entity == null) { return false; }
        try
        {
            _context.Pilots.Remove(entity);
            _context.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public IEnumerable<PilotEntity> GetAll()
    {
        return _context.Pilots.AsEnumerable();
    }

    public PilotEntity? GetById(int Id)
    {
        return _context.Pilots.SingleOrDefault(m=>m.Id==Id);
    }

    public bool Insert(PilotEntity toInsert)
    {
        
        
        try
        {
            _context.Pilots.Add(toInsert);
            _context.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool Update(PilotEntity toUpdate)
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