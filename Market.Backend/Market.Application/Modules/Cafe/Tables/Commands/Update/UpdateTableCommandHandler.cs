using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Application.Modules.Cafe.Tables.Commands.Update
{
    public sealed class UpdateTableCommandHandler(IAppDbContext ctx) : IRequestHandler<UpdateTableCommand, Unit>
    {
        public async Task<Unit> Handle (UpdateTableCommand request, CancellationToken ct)
        {
            var entity=await ctx.CafeTables.Where(x=>x.Id==request.Id).FirstOrDefaultAsync(ct);

            if (entity is null)
            {
                throw new MarketNotFoundException($"Sto ID = {request.Id} nije pronađen");
            }

            var exists = await ctx.CafeTables.AnyAsync(x => x.Id != request.Id && x.TableNumber == request.TableNumber, ct);

            if (exists)
            {
                throw new MarketConflictException($"Sto sa brojem {request.TableNumber} već postoji!");
            }

            entity.TableNumber = request.TableNumber;
            entity.IsEnabled = request.IsEnabled;

            await ctx.SaveChangesAsync(ct);
            return Unit.Value;
        }
    }
}
