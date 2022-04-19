namespace PaymentsGatewayApi.WebApi.Services;

using PaymentsGatewayApi.Application.Common.Interfaces.Services;
using Microsoft.AspNetCore.Http;
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
