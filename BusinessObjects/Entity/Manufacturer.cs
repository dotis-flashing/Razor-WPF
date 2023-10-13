﻿using System;
using System.Collections.Generic;

namespace BusinessObjects.Entity
{
    public partial class Manufacturer
    {
        public Manufacturer()
        {
            CarInformations = new HashSet<CarInformation>();
        }

        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; } = null!;
        public string? Description { get; set; }
        public string? ManufacturerCountry { get; set; }
        public string ManufacturerStatus { get; set; }

        public virtual ICollection<CarInformation> CarInformations { get; set; }
    }
}
