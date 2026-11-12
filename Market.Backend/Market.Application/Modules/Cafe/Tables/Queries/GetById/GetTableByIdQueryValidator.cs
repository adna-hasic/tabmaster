using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Market.Application.Modules.Cafe.Tables.Queries.GetById
{
    public sealed class GetTableByIdQueryValidator : AbstractValidator<GetTableByIdQuery>
    {
        public GetTableByIdQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id mora biti pozitivan broj!");
        }
    }
}
