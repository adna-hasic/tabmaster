using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Application.Modules.Cafe.Tables.Queries.GetById
{
    public class GetTableByIdQuery : IRequest<GetTableByIdQueryDto>
    {
        public int Id { get; set; }
    }
}
