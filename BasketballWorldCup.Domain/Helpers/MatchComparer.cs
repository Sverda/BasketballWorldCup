using BasketballWorldCup.Model.Competition;
using System.Collections.Generic;

namespace BasketballWorldCup.Domain.Helpers
{
    internal class MatchComparer : IEqualityComparer<Match>
    {
        public bool Equals(Match x, Match y)
        {
            return x.Host.Id == y.Host.Id
                   || x.Guest.Id == y.Guest.Id
                   || x.Host.Id == y.Guest.Id;
        }

        public int GetHashCode(Match obj)
        {
            return obj.Guest.Id.GetHashCode() ^ obj.Host.Id.GetHashCode();
        }
    }
}
