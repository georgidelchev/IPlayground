using System.ComponentModel.DataAnnotations;

using IPlayground.Data.Common.Models;

namespace IPlayground.Data.Models
{
    public class Contact : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(60)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(30)]
        public string Email { get; set; }

        [MaxLength(1000)]
        public string Message { get; set; }
    }
}
