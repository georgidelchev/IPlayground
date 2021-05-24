using System.Collections.Generic;

using IPlayground.Data.Common.Models;

namespace IPlayground.Data.Models
{
    public class Game : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
            = new HashSet<Category>();

        public virtual ICollection<Picture> Pictures { get; set; }
            = new HashSet<Picture>();
    }
}
