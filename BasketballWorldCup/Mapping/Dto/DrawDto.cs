namespace BasketballWorldCup.Mapping.Dto
{
    public class DrawDto
    {
        public int Id { get; set; }

        public PotDto[] Pots { get; set; }

        public GroupDto[] Groups { get; set; }
    }
}
