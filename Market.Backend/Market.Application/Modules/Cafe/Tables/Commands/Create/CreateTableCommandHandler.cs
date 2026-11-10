using Market.Domain.Entities.Cafe;
using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Application.Modules.Cafe.Tables.Commands.Create
{
    public class CreateTableCommandHandler(IAppDbContext context) : IRequestHandler<CreateTableCommand, int>
    {
        public async Task<int> Handle(
            CreateTableCommand request, CancellationToken cancellationToken)
        {
            bool exists = await context.CafeTables.AnyAsync(x => x.TableNumber == request.TableNumber, cancellationToken);

            if (exists)
            {
                throw new MarketConflictException($"Sto sa brojem {request.TableNumber} vec postoji!");
            }

            var table = new CafeTableEntity
            {
                TableNumber = request.TableNumber,
                IsEnabled = request.IsEnabled
            };

            context.CafeTables.Add(table);
            await context.SaveChangesAsync(cancellationToken);

            return table.Id;
        }
    }
}
