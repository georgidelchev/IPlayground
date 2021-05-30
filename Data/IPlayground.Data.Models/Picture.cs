using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using IPlayground.Data.Common.Models;

namespace IPlayground.Data.Models
{
    public class Picture : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(6)]
        public string Extension { get; set; }

        public ICollection<Game> Games { get; set; }
            = new HashSet<Game>();
    }
}
