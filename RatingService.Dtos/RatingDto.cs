namespace RatingService.Dtos
{
    public record RatingDto()
    {
        public int Id { get; init; }
        public int UserId { get; init; }
        public int ProviderId { get; init; }
        public double Point { get; set; }
    }
}
