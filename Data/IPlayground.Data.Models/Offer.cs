using System;
using IPlayground.Data.Common.Models;

namespace IPlayground.Data.Models
{
    public class Offer : BaseDeletableModel<string>
    {
        public Offer()
        {
            this.Id = Guid
                .NewGuid()
                .ToString();
        }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
