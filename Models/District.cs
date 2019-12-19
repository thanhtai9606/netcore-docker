using System;
using System.Collections.Generic;

namespace acb_app.Models
{
    public partial class District
    {
        public string DistrictId { get; set; }
        public string DistrictName { get; set; }
        public string EnglishName { get; set; }
        public string Level { get; set; }
        public int ProvinceId { get; set; }
    }
}
