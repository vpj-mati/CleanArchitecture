using ProcesoAutonomo.ServiceA.Application.Common.Interfaces;

namespace ProcesoAutonomo.ServiceA.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
