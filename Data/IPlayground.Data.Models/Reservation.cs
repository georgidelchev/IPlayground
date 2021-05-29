using System;
using System.ComponentModel.DataAnnotations;

using IPlayground.Data.Common.Models;

namespace IPlayground.Data.Models
{
    public class Reservation : BaseDeletableModel<string>
    {
        public Reservation()
        {
            this.Id = Guid
                .NewGuid()
                .ToString();
        }

        [Required]
        [MaxLength(60)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(30)]
        public string Email { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [MaxLength(1000)]
        public string Message { get; set; }
    }
}
