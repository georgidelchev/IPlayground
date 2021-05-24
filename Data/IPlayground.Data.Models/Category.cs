using System.Collections.Generic;

using IPlayground.Data.Common.Models;

namespace IPlayground.Data.Models
{
    public class Category : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public virtual ICollection<Game> Games { get; set; }
            = new HashSet<Game>();
    }
}
