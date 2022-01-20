﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Furniture_Shop_Backend.Models
{
    public partial class Import
    {
        public Import()
        {
            ImportDetails = new HashSet<ImportDetail>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public byte[] CreatedAt { get; set; }
        public decimal? Cost { get; set; }

        public virtual ICollection<ImportDetail> ImportDetails { get; set; }
    }
}
