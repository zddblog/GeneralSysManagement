using General.Entities.GeneralModels;

namespace General.Services.General.EntityServices
{
    public class CategoryService : ICategoryService
    {
        private readonly CoreContext _coreContext;

        public CategoryService(CoreContext coreContext)
        {
            _coreContext = coreContext;
        }
        public void Add(Category category)
        {
            _coreContext.Add(category);
            _coreContext.SaveChanges();
        }

        public Category GetSingle(object id)
        {
            return _coreContext.Category.Find(id);
        }
    }
}
