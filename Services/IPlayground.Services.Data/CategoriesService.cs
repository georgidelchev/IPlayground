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

        public async Task<int> CreateAsync(string categoryName)
        {
            var category = new Category()
            {
                Name = categoryName,
            };

            await this.categoriesRepository.AddAsync(category);
            await this.categoriesRepository.SaveChangesAsync();

            return category.Id;
        }

        public bool IsCategoryExists(string categoryName)
            => this.categoriesRepository
                .AllAsNoTracking()
                .Any(c => c.Name == categoryName);

        public int GetCategoryId(string categoryName)
            => this.categoriesRepository
                .All()
                .FirstOrDefault(c => c.Name == categoryName)
                .Id;
    }
}
