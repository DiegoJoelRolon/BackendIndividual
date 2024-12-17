namespace Domain.Entities
{
    public class Users
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public List<Tasks> Tasks { get; set; }
    }
}
