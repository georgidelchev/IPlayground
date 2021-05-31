using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using IPlayground.Data.Common.Models;

namespace IPlayground.Data.Models
{
    public class Tag : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(15)]
        public string Name { get; set; }

        public virtual ICollection<News> News { get; set; }
            = new HashSet<News>();
    }
}
