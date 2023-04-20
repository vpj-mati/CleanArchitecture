using System.Security.Claims;

using ProcesoAutonomo.ServiceA.Application.Common.Interfaces;

namespace ProcesoAutonomo.ServiceA.WebApi.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string? UserId => _httpContextAccessor.HttpContext?
                            .User?
                            .FindFirstValue("user_id");

    public string? UserName => _httpContextAccessor.HttpContext?
                            .User?
                            .FindFirstValue("name");
}
