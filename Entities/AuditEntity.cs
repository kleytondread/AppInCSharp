using System;
using System.Collections.Generic;
using System.Text;

namespace Pitang.ONS.Treinamento.Entities
{
    public abstract class AuditEntity : BaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public bool IsDeleted { get; set; } 
    }
}
