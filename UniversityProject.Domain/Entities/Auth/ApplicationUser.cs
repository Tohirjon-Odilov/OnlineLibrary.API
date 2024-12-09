namespace UniversityProject.Domain.Entities.Auth
{
    public class ApplicationUser 
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? PictureUrl { get; set; }
        public string Role { get; set; }
        public int CountryId { get; set; }

        public virtual ICollection<Report> Report { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<UserBook>? UserBooks { get; set; }
    }
}
