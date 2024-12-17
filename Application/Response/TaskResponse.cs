namespace Application.Response
{
    public class TaskResponse
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public Guid ProjectID { get; set; }
        public GenericResponse Status { get; set; }
        public UserResponse UserAssigned { get; set; }

    }
}
