using Market.Application.Modules.Cafe.Tables.Commands.Create;
using Market.Application.Modules.Cafe.Tables.Commands.Delete;
using Market.Application.Modules.Cafe.Tables.Commands.Update;
using Market.Application.Modules.Cafe.Tables.Queries.List;
using Market.Application.Modules.Cafe.Tables.Queries.GetById;
using Market.Shared.Constants;

namespace Market.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Policy = PolicyNames.Admin)]
    public class TablesController(ISender sender) : ControllerBase
    {
        [HttpGet("{id:int}")]
        public async Task<GetTableByIdQueryDto> GetById(int id, CancellationToken ct)
        {
            var table = await sender.Send(new GetTableByIdQuery { Id = id }, ct);

            return table;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateTableCommand command, CancellationToken ct)
        {
            int id = await sender.Send(command, ct);

            return CreatedAtAction(nameof(GetById), new { id }, new { id });
        }

        [HttpPut("{id:int}")]
        public async Task Update(int id, UpdateTableCommand command, CancellationToken ct)
        {
            command.Id = id;
            await sender.Send(command, ct);
        }

        [HttpDelete("{id:int}")]
        public async Task Delete(int id, CancellationToken ct)
        {
            await sender.Send(new DeleteTableCommand { Id = id }, ct);
        }

        [HttpGet]
        public async Task<PageResult<ListTablesQueryDto>> List([FromQuery] ListTablesQuery query, CancellationToken ct)
        {
            var result = await sender.Send(query, ct);
            return result;
        }
    }
}
