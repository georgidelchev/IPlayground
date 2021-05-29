using System;
using System.ComponentModel.DataAnnotations;

using IPlayground.Data.Common.Models;

namespace IPlayground.Data.Models
{
    public class Gallery : BaseDeletableModel<string>
    {
        public Gallery()
        {
            this.Id = Guid
                .NewGuid()
                .ToString();
        }

        [Required]
        public string Extension { get; set; }

        [Required]
        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }
    }
}
