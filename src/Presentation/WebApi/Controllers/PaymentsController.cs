namespace PaymentsGatewayApi.WebApi.Controllers;

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PaymentsGatewayApi.Application.Common.Wrappers;
using PaymentsGatewayApi.Application.Features.Payments.Commands.CreatePayment;
using PaymentsGatewayApi.Application.Features.Payments.Queries.GetAllPayments;
using PaymentsGatewayApi.Application.Features.Payments.Queries.GetPaymentById;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class PaymentsController : ControllerBase
{
    private readonly ILogger<PaymentsController> _logger;
    private readonly IMediator _mediator;

    public PaymentsController(
        ILogger<PaymentsController> logger,
        IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    // POST /Payments
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] CreatePaymentCommand cmd)
    {
        _logger.LogDebug($"Create Payment {cmd}");

        var response = await _mediator.Send(cmd);

        return Created($"/Payments/{response.Data.Id}", response.Data);
    }

    // GET /Payments/5
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(string id)
    {
        string message = $"Get Payment {id}";
        _logger.LogDebug(message: message);

        var response = await _mediator.Send(new GetPaymentByIdQuery() { Id = id });
        return Ok(response.Data);
    }

    // GET: /Payments
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(int index, int size)
    {
        _logger.LogDebug($"Get Payments. index:{index} size:{size} ");

        var qry = new GetAllPaymentsQuery()
        {
            PageNumber = index + 1,
            PageSize = size < 1 ? 10 : (size > 1000 ? 1000 : size)
        };

        var response = await _mediator.Send(qry);

        return Ok(response.Data);
    }
}