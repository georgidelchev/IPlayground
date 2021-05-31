using System.Threading.Tasks;

using IPlayground.Data.Common.Repositories;
using IPlayground.Data.Models;

namespace IPlayground.Services.Data
{
    public class PicturesService : IPicturesService
    {
        private readonly IDeletableEntityRepository<Picture> picturesRepository;

        public PicturesService(IDeletableEntityRepository<Picture> picturesRepository)
        {
            this.picturesRepository = picturesRepository;
        }

        public async Task<Picture> CreateAsync(string extension)
        {
            var picture = new Picture()
            {
                Extension = extension,
            };

            await this.picturesRepository.AddAsync(picture);
            await this.picturesRepository.SaveChangesAsync();

            return picture;
        }
    }
}
