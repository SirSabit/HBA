namespace RatingService.Dtos
{
    public record RatingDto()
    {
        public int UserId { get; init; }
        public int ProviderId { get; init; }
        public double Point { get; init; }
    }
}
