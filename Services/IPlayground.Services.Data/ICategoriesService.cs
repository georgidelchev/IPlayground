using System.Threading.Tasks;

namespace IPlayground.Services.Data
{
    public interface ICategoriesService
    {
        Task CreateAsync();

        bool IsCategoryExists(string categoryName);
    }
}