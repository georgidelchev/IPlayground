using System;

using IPlayground.Data.Common.Models;

namespace IPlayground.Data.Models
{
    public class Picture : BaseDeletableModel<string>
    {
        public Picture()
        {
            this.Id = Guid
                .NewGuid()
                .ToString();
        }

        public string Extension { get; set; }

        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }
    }
}
