using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Application.Modules.Cafe.Tables.Queries.List
{
    public sealed class ListTablesQuery : BasePagedQuery<ListTablesQueryDto>
    {
        public bool? OnlyEnabled { get; init; }
        public int? TableNumber { get; init; }
    }
}
