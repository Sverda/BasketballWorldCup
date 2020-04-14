using System.Collections.Generic;

namespace BasketballWorldCup.Model
{
    public class Pot
    {
        public int Id { get; set; }

        public int DrawId { get; set; }

        public Draw Draw { get; set; }

        public ICollection<TeamPot> TeamPots { get; set; }
    }
}
