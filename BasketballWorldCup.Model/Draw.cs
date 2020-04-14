using System.Collections.Generic;

namespace BasketballWorldCup.Model
{
    public class Draw
    {
        public int Id { get; set; }

        public ICollection<Pot> Pots { get; set; }

        public ICollection<Group> Groups { get; set; }
    }
}
