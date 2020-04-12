using System.Collections.Generic;

namespace BasketballWorldCup.Model
{
    public class Pot
    {
        public int Id { get; set; }

        public ICollection<Team> Teams { get; set; }

        public int DrawId { get; set; }

        public Draw Draw { get; set; }
    }
}
