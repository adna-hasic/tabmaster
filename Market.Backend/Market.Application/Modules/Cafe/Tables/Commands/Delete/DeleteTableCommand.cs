using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Application.Modules.Cafe.Tables.Commands.Delete
{
    public class DeleteTableCommand : IRequest<Unit>
    {
        public required int Id { get; set; }
    }
}
