using General.Entities.GeneralModels;
using General.NetCore.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace General.Entities
{
    public class EfRepository<TModel> : IRepository<TModel> where TModel : class
    {
        private readonly CoreContext _coreContext;

        public EfRepository(CoreContext coreContext)
        {
            this._coreContext = coreContext;
        }
        public DbContext dbContext
        {
            get
            {
                return _coreContext;
            }
        }

        public DbSet<TModel> Entities
        {
            get
            {
                return _coreContext.Set<TModel>();
            }
        }

        public void Add(TModel model)
        {
            _coreContext.Add(model);
            _coreContext.SaveChanges();
        }

        public void Delete(object Id)
        {
            var entity = GetSingle(Id);

            if (entity != null)
            {
                _coreContext.Remove(entity);
                _coreContext.SaveChanges();
            }

        }

        public IEnumerable<TModel> GetList()
        {
            return _coreContext.Set<TModel>().ToList();
        }

       
        public TModel GetSingle(object Id)
        {
            return _coreContext.Set<TModel>().Find(Id);
        }


        public void Update(TModel model)
        {
            _coreContext.Update(model);
        }

      
    }
}
