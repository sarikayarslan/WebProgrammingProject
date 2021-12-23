namespace WebProgrammingProject.Models
{
    public class UserAdvertisement
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public int AdvertisementId { get; set; }
        public Advertisement Advertisement { get; set; }
        public User User{ get; set; }

    }
}
