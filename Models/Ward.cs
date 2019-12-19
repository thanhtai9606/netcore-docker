using System;
using System.Collections.Generic;

namespace acb_app.Models
{
    public partial class Ward
    {
        public string WarId { get; set; }
        public string WardName { get; set; }
        public string EnglishName { get; set; }
        public string Level { get; set; }
        public int DistrictId { get; set; }
    }
}
