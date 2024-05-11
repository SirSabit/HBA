namespace RatingService.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
    }
}
