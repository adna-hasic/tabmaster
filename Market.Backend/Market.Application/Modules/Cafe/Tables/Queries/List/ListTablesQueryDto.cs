using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Application.Modules.Cafe.Tables.Queries.List
{
    public sealed class ListTablesQueryDto
    {
        public required int Id { get; init; }
        public required int TableNumber { get; init; }
        public required bool IsEnabled { get; init; }

    }
}
