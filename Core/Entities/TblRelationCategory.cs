using System;
using System.Collections.Generic;

namespace DbFirstProj.Entities
{
    public partial class TblRelationCategory
    {
        public Guid RelationId { get; set; }
        public Guid CategoryId { get; set; }
    }
}
