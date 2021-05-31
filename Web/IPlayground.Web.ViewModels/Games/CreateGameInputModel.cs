using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Http;

namespace IPlayground.Web.ViewModels.Games
{
    public class CreateGameInputModel
    {
        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [Range(typeof(decimal), "0.1", "1000")]
        public decimal Price { get; set; }

        [Required]
        [MinLength(20)]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        [DisplayName("Category")]
        public string CategoryName { get; set; }

        [Required]
        public IFormFile Picture { get; set; }
    }
}
