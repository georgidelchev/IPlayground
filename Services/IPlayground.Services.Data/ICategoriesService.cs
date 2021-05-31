using System.Threading.Tasks;

namespace IPlayground.Services.Data
{
    public interface ICategoriesService
    {
        Task<int> CreateAsync(string categoryName);

        bool IsCategoryExists(string categoryName);

        int GetCategoryId(string categoryName);
    }
}
