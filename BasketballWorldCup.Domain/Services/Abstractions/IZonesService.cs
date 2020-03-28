using System.Collections.Generic;

namespace BasketballWorldCup.Domain.Services.Abstractions
{
    public interface IZonesService
    {
        IEnumerable<string> GetZones();
    }
}