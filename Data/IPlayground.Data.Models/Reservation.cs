using System;

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

        public string FullName { get; set; }

        public string Email { get; set; }

        public DateTime Date { get; set; }

        public string PhoneNumber { get; set; }

        public string Message { get; set; }
    }
}
