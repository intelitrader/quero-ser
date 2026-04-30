using Microsoft.AspNetCore.Mvc;
using MediatR;
using Intelitrader.Zap.Application.Contacts.Commands;

namespace Intelitrader.Zap.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ContactsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateContactCommand command)
    {
        var result = await _mediator.Send(command);

        if (result is null)
        {
            return BadRequest(new { message = "Erro ao processar o comando." });
        }

        return Ok(result);
    }
}