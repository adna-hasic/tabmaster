using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Application.Modules.Cafe.Tables.Commands.Create
{
    public sealed class CreateTableCommandValidator : AbstractValidator<CreateTableCommand>
    {

        public CreateTableCommandValidator() {
            RuleFor(x => x.TableNumber).GreaterThan(0).WithMessage("Broj stola mora biti veći od nule!");
        }
    }
}
