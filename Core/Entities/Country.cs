﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbFirstProj.Entities
{
    [Table("tblCountry")]
    public partial class Country
    {
        public Country()
        {
            CreatedAt = DateTime.Now;
            CreatedBy = "AG";
            IsDisabled = false;
            IsDefault = false;
            Name = "AG";
        }

        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsDefault { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Iso31662 { get; set; }
        public string Iso31663 { get; set; }
        public Guid? DefaultVatId { get; set; }
        public string PostalCodeFormat { get; set; }
        public List<RelationAddress> RelationAddresses { get; set; }
    }
}
