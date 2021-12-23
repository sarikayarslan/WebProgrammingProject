namespace WebProgrammingProject.Models
{
    public class UserAdvertisement
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AdvertisementId { get; set; }
        public User User{ get; set; }
        public Advertisement Advertisement { get; set; }
    }
}
