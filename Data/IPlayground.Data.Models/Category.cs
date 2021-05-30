using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using IPlayground.Data.Common.Models;

namespace IPlayground.Data.Models
{
    public class Category : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public virtual ICollection<Game> Games { get; set; }
            = new HashSet<Game>();

        public virtual ICollection<Product> Products { get; set; }
            = new HashSet<Product>();
    }
}
