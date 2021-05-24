using System.Collections.Generic;

using IPlayground.Data.Common.Models;

namespace IPlayground.Data.Models
{
    public class Product : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
            = new HashSet<Category>();
    }
}
