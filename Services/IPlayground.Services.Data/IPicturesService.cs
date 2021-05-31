using System.Threading.Tasks;

using IPlayground.Data.Models;

namespace IPlayground.Services.Data
{
    public interface IPicturesService
    {
        Task<Picture> CreateAsync(string extension);
    }
}
