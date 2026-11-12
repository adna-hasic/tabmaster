using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Application.Modules.Cafe.Tables.Commands.Update
{
    public sealed class UpdateTableCommandValidator:AbstractValidator<UpdateTableCommand>
    {
        public UpdateTableCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.TableNumber).GreaterThan(0).WithMessage("Broj stola mora biti veći od 0");
        }
    }
}
