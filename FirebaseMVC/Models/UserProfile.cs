namespace BusinessVenture.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string FirebaseUserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public UserProfile UP { get; set; }


    }
}
