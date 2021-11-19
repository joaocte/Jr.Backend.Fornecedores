using Jr.Backend.Fornecedores.Domain.Commands;
using Jr.Backend.Fornecedores.Domain.Commands.Request;
using Jr.Backend.Fornecedores.Domain.Commands.Response;
using Jr.Backend.Fornecedores.Domain.Querys.Request;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jr.Backend.Fornecedor.Api.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class FornecedorController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Fornecedores.Domain.Fornecedor>> Get([FromServices] IMediator mediator, [FromQuery] ObterFornecedorQuery query)
        {
            return await mediator.Send(query);
        }

        // POST api/<PessoaController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CadastrarFornecedorCommandResponse>> Post([FromServices] IMediator mediator,
            [FromBody] CadastrarFornecedorCommand command)
        {
            CadastrarFornecedorCommandResponse commandResult = await mediator.Send(command);
            return CreatedAtAction("Get", new { id = commandResult?.Id }, commandResult);
        }

        // PUT api/<PessoaController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<AtualizarFornecedorCommandResponse> Put(Guid id, [FromBody] FornecedorCommandRequest command, [FromServices] IMediator mediator)
        {
            //var newCommand = new AtualizarFornecedorCommand(
            //return await mediator.Send(newCommand);

            return default;
        }
    }
}