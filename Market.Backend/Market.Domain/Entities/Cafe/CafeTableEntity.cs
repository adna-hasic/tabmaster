using Market.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Domain.Entities.Cafe
{
    public class CafeTableEntity : BaseEntity
    {
        public int TableNumber { get; set; }
        public bool IsEnabled { get; set; } = true;
    }
}
