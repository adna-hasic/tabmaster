using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Application.Modules.Cafe.Tables.Commands.Update
{
    public sealed class UpdateTableCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public int Id { get; set; }
        public required int TableNumber { get; set; }
        public required bool IsEnabled { get; set; }
    }
}
