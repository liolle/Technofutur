using AspInterfaces;
using tf2024_asp_razor.Models.Entities.Taxable;

namespace AspcoreBll;

public class MecanicService : IMecanicService
{

    private readonly IDataContext _context;

    public MecanicService(IDataContext context)
    {
        this._context = context;
    }

    public bool Delete(int Id)
    {
            MecanicEntity? entity = _context.Mechanics.SingleOrDefault(p => p.Id == Id);
        if (entity == null) { return false; }
        try
        {
            _context.Mechanics.Remove(entity);
            _context.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public IEnumerable<MecanicEntity> GetAll()
    {
        return _context.Mechanics.AsEnumerable();
    }

    public MecanicEntity? GetById(int Id)
    {
        return _context.Mechanics.SingleOrDefault(m=>m.Id==Id);
    }

    public bool Insert(MecanicEntity toInsert)
    {
        
        
        try
        {
            _context.Mechanics.Add(toInsert);
            _context.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool Update(MecanicEntity toUpdate)
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