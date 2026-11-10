using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Application.Modules.Cafe.Tables.Queries.List
{
    public sealed class ListTablesQueryHandler(IAppDbContext ctx) : IRequestHandler<ListTablesQuery, PageResult<ListTablesQueryDto>> 
    {
        public async Task<PageResult<ListTablesQueryDto>> Handle (ListTablesQuery request, CancellationToken ct)
        {
            var q = ctx.CafeTables.AsNoTracking();

            if(request.OnlyEnabled is not null)
            {
                q = q.Where(x => x.IsEnabled == request.OnlyEnabled);
            }

            if(request.TableNumber is not null)
            {
                q = q.Where(x => x.TableNumber == request.TableNumber);
            }

            var projectedQuery = q.OrderBy(x => x.TableNumber).Select(x => new ListTablesQueryDto
            {
                Id = x.Id,
                TableNumber = x.TableNumber,
                IsEnabled = x.IsEnabled,
            });

            return await PageResult<ListTablesQueryDto>.FromQueryableAsync(projectedQuery, request.Paging, ct);
        }
    }
}
