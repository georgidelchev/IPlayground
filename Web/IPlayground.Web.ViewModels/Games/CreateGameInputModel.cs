using System.ComponentModel.DataAnnotations;

namespace IPlayground.Web.ViewModels.Games
{
    public class CreateGameInputModel
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        [MaxLength(20)]
        public string CategoryName { get; set; }
    }
}
