using System;
using System.Collections.Generic;

#nullable disable

namespace Dating.API.Models
{
    public partial class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool? IsMain { get; set; }
        public string PublicId { get; set; }
        public int? AppUserId { get; set; }

        public virtual AppUser AppUser { get; set; }
    }
}
