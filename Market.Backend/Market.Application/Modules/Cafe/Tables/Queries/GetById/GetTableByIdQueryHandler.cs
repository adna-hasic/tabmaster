using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Market.Application.Modules.Cafe.Tables.Queries.GetById
{
    public class GetTableByIdQueryHandler(IAppDbContext context) : IRequestHandler<GetTableByIdQuery, GetTableByIdQueryDto>
    {
        public async Task<GetTableByIdQueryDto> Handle (GetTableByIdQuery request, CancellationToken ct)
        {
            var table = await context.CafeTables.Where(x => x.Id == request.Id).Select(x => new GetTableByIdQueryDto
            {
                Id = x.Id,
                TableNumber = x.TableNumber,
                IsEnabled = x.IsEnabled
            }).FirstOrDefaultAsync(ct);

            if (table is null)
            {
                throw new MarketNotFoundException($"Sto (ID={request.Id}) nije pronađen!");
            }

            return table;
        }
    }
}
