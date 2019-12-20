using System;
using System.Collections.Generic;

namespace acb_app.Models
{
    public partial class Province
    {
        public Province()
        {
            District = new HashSet<District>();
        }

        public string ProviceId { get; set; }
        public string ProviceName { get; set; }
        public string EnglishName { get; set; }
        public string Level { get; set; }

        public virtual ICollection<District> District { get; set; }
    }
}
