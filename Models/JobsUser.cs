namespace WebProgrammingProject.Models
{
    public class JobsUser
    {
        public int JobsUserId { get; set; }
        public string UserId { get; set; }
        public User UserName { get; set; }
        public int AdvertisementId { get; set; }
        public Advertisement Advertisement { get; set; }
        public bool IsAccepted { get; set; }

    }
}
