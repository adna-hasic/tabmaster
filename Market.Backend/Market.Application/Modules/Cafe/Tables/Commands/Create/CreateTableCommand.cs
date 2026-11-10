using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Application.Modules.Cafe.Tables.Commands.Create
{
    public class CreateTableCommand : IRequest<int>
    {
        public int TableNumber { get; set; }
        public bool IsEnabled { get; set; } = true;
    }
}
