﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbFirstProj.Entities
{
    [Table("tblRelationCategory")]
    public partial class RelationCategory
    {
        public Guid RelationId { get; set; }
        public Guid CategoryId { get; set; }
    }
}
