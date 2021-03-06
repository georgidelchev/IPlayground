using System;
using System.ComponentModel.DataAnnotations;

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

        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
    }
}
