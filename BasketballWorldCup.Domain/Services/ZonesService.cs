using BasketballWorldCup.Domain.Services.Abstractions;
using BasketballWorldCup.Model;
using BasketballWorldCup.Model.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BasketballWorldCup.Domain.Services
{
    public class ZonesService : IZonesService
    {
        public IEnumerable<string> GetZones()
        {
            return Enum.GetValues(typeof(QualificationZone)).Cast<QualificationZone>().Select(z => z.GetDescription());
        }
    }
}
