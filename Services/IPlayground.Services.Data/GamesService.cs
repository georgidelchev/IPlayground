using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using IPlayground.Data.Common.Repositories;
using IPlayground.Data.Models;
using IPlayground.Services.Mapping;
using IPlayground.Web.ViewModels.Games;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace IPlayground.Services.Data
{
    public class GamesService : IGamesService
    {
        private readonly IDeletableEntityRepository<Game> gamesRepository;
        private readonly ICategoriesService categoriesService;
        private readonly IPicturesService picturesService;
        private readonly string[] allowedExtensions = { "jpg", "png", "jfif", "exif", "gif", "bmp", "ppm", "pgm", "pbm", "pnm", "heif", "bat" };

        public GamesService(
            IDeletableEntityRepository<Game> gamesRepository,
            ICategoriesService categoriesService,
            IPicturesService picturesService)
        {
            this.gamesRepository = gamesRepository;
            this.categoriesService = categoriesService;
            this.picturesService = picturesService;
        }

        /// <summary>
        /// Create new game
        /// </summary>
        /// <param name="input">input data from the user</param>
        /// <param name="userId">id of the current user</param>
        /// <param name="imagePath">the path of the image</param>
        /// <returns></returns>
        public async Task CreateAsync(CreateGameInputModel input, string userId, string imagePath)
        {
            Directory.CreateDirectory($"{imagePath}/Pictures/GamesPictures/");
            Directory.CreateDirectory($"{imagePath}/Pictures/GamesPictures/Thumbnails/");

            var extension = Path
                .GetExtension(input.Picture.FileName)
                .TrimStart('.')
                .TrimEnd();

            if (!this.allowedExtensions
                .Any(e => e.ToLower().EndsWith(extension.ToLower())))
            {
                throw new Exception($"Invalid image extension {extension}.");
            }

            var game = new Game()
            {
                AddedByUserId = userId.Trim(),
                Description = input.Description.Trim(),
                Price = input.Price,
                Name = input.Name.Trim(),
                CategoryId = this.categoriesService.IsCategoryExists(input.CategoryName.Trim()) == true ?
                    this.categoriesService.GetCategoryId(input.CategoryName.Trim()) :
                    this.categoriesService.CreateAsync(input.CategoryName.Trim()).Result,
            };

            game.Pictures.Add(await this.picturesService.CreateAsync(extension));

            await this.gamesRepository.AddAsync(game);
            await this.gamesRepository.SaveChangesAsync();

            var physicalPath = $"{imagePath}/Pictures/GamesPictures/";
            var pictureFormat = $"{game.Id}.{extension}";
            var fullPhysicalPath = physicalPath + pictureFormat;

            await using var fileStream = new FileStream(fullPhysicalPath, FileMode.Create);

            await input.Picture.CopyToAsync(fileStream);
            await fileStream.DisposeAsync();

            await SaveThumbnailPictureLocally(fullPhysicalPath, physicalPath, pictureFormat);
        }

        /// <summary>
        /// Get all games from the database.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="page">starting page for pagination</param>
        /// <param name="itemsPerPage">count of the games per page</param>
        /// <returns></returns>
        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage)
            => this.gamesRepository
                .All()
                .To<T>()
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToList();

        /// <summary>
        /// Get details about the selected game.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">game id</param>
        /// <returns></returns>
        public T GetDetails<T>(int id)
            => this.gamesRepository
                .All()
                .Where(g => g.Id == id)
                .To<T>()
                .FirstOrDefault();

        /// <summary>
        /// Resizes the given image and save it locally.
        /// </summary>
        /// <param name="fullPhysicalPath">full physical path</param>
        /// <param name="physicalPath">physical path to child folder</param>
        /// <param name="pictureFormat">format of the picture</param>
        /// <returns></returns>
        private static async Task SaveThumbnailPictureLocally(string fullPhysicalPath, string physicalPath, string pictureFormat)
        {
            using var thumbnailImage = await Image.LoadAsync(fullPhysicalPath);
            thumbnailImage.Mutate(i => i.Resize(500, 300));
            await thumbnailImage.SaveAsync($"{physicalPath}Thumbnails/thumbnail-{pictureFormat}");
        }
    }
}
