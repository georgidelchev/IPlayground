using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using IPlayground.Data.Common.Models;

namespace IPlayground.Data.Models
{
    public class News : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Content { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
            = new HashSet<Tag>();
    }
}
