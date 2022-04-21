namespace PaymentsGatewayApi.WebApi.Services;

using Microsoft.AspNetCore.Http;
using PaymentsGatewayApi.Application.Common.Interfaces.Services;
using System.Linq;

public class CurrentClientService : ICurrentClientService
{
    public CurrentClientService(IHttpContextAccessor httpContextAccessor)
    {
        ClientId = httpContextAccessor.HttpContext?.User?.Claims?.FirstOrDefault(c => c.Type == "client_id")?.Value
                 ?? "anonymous";
    }

    public string ClientId { get; }
}