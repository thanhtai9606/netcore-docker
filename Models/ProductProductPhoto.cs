using System;
using System.Collections.Generic;

namespace acb_app.Models
{
    public partial class ProductProductPhoto
    {
        public int ProductId { get; set; }
        public int ProductPhotoId { get; set; }
        public bool PrimaryImage { get; set; }
        public int Qrcode { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
