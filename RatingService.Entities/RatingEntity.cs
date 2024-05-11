namespace RatingService.Entities
{
    public class RatingEntity : BaseEntity
    {
        public double Point { get; set; }
        public int UserId { get; set; }
        public int ProviderId { get; set; }
    }
}
