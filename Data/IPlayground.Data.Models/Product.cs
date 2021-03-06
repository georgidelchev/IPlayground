using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using IPlayground.Data.Common.Models;

namespace IPlayground.Data.Models
{
    public class Product : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
            = new HashSet<Category>();
    }
}
