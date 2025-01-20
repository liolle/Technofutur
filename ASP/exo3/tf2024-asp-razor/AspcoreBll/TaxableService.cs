using AspInterfaces;
using tf2024_asp_razor.Models.Entities;

namespace AspcoreBll
{
    public class TaxableService : ITaxableService
    {
        private readonly IDataContext _context;

        public TaxableService(IDataContext context)
        {
            this._context = context;
        }

        public bool Delete(int Id)
        {
             TaxableEntity? entity = _context.Taxables.SingleOrDefault(p => p.Id == Id);
            if (entity == null) { return false; }
            try
            {
                _context.Taxables.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<TaxableEntity> GetAll()
        {
            return _context.Taxables.AsEnumerable();
        }

        public TaxableEntity? GetById(int Id)
        {
            return _context.Taxables.SingleOrDefault(m=>m.Id==Id);
        }

        public bool Insert(TaxableEntity toInsert)
        {
            
            
            try
            {
                _context.Taxables.Add(toInsert);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(TaxableEntity toUpdate)
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
}
