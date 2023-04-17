namespace ProcesoAutonomo.ServiceA.Infrastructure.Identity;

public class IdentityAuthenticationOptions
{
    public string? DefaultScheme { get; set; }
    public bool RequireHttpsMetadata { get; set; }
    public string? ApiName { get; set; }
    public string? Authority { get; set; }
}
