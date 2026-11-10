using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Application.Modules.Cafe.Tables.Commands.Delete
{
    public class DeleteTableCommandHandler(IAppDbContext context, IAppCurrentUser appCurrentUser) :
        IRequestHandler<DeleteTableCommand, Unit>
    {
        public async Task<Unit> Handle (DeleteTableCommand request, CancellationToken ct)
        {
            if (!appCurrentUser.IsAdmin)
            {
                throw new MarketForbiddenException("Samo admin može brisati stolove!");
            }

            var table = await context.CafeTables.FirstOrDefaultAsync(x => x.Id == request.Id, ct);


            if (table is null)
                throw new MarketNotFoundException($"Stol ID = {request.Id} nije pronađen.");

            context.CafeTables.Remove(table);
            await context.SaveChangesAsync(ct);

            return Unit.Value;
        }
    }
}
