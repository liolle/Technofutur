using tf2024_asp_razor.Database;
using tf2024_asp_razor.Models.Entities;


namespace AspcoreBll;

class FlightService : IRepository<FlightEntity>
{

    private readonly IDataContext _context;

    public FlightService(IDataContext context)
    {
        this._context = context;
    }

    public bool Delete(int Id)
    {
        return false;
    }

    public IEnumerable<FlightEntity> GetAll()
    {
        return _context.Flights.AsEnumerable();
    }

    public FlightEntity? GetById(int Id)
    {
        return _context.Flights.SingleOrDefault(m=>m.NbFlights==Id);
    }

    public bool Insert(FlightEntity toInsert)
    {
        
        try
        {
            _context.Flights.Add(toInsert);
            _context.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool Update(FlightEntity toUpdate)
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