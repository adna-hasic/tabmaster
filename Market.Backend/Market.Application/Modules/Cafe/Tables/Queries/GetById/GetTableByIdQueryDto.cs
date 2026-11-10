using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Application.Modules.Cafe.Tables.Queries.GetById
{
    public class GetTableByIdQueryDto
    {
        public required int Id { get; init; }
        public required int TableNumber { get; init; }
        public required bool IsEnabled { get; init; }
    }
}
