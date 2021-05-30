using System.Linq;
using System.Threading.Tasks;
using IPlayground.Data.Common.Repositories;
using IPlayground.Data.Models;

namespace IPlayground.Services.Data
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepository;

        public CategoriesService(IDeletableEntityRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public async Task CreateAsync()
        {
            throw new System.NotImplementedException();
        }

        public bool IsCategoryExists(string categoryName)
            => this.categoriesRepository
                .AllAsNoTracking()
                .Any(c => c.Name == categoryName);
    }
}
