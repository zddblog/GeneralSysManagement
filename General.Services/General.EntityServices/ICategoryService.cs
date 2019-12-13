using General.Entities.GeneralModels;

namespace General.Services.General.EntityServices
{
    public interface ICategoryService
    {
        Category GetSingle(object id);

        void Add(Category category);
    }
}
