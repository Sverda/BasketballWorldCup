using BasketballWorldCup.Model;
using System.Collections.Generic;

namespace BasketballWorldCup.Domain.Services.Abstractions
{
    public interface IGroupsService
    {
        IEnumerable<Group> DrawIntoGroups(Pot[] pots);
    }
}