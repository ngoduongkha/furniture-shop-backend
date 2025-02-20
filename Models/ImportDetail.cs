﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Furniture_Shop_Backend.Models
{
    public partial class ImportDetail
    {
        public int ImportId { get; set; }
        public int ProductId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Cost { get; set; }

        public virtual Import Import { get; set; }
        public virtual Product Product { get; set; }
    }
}
