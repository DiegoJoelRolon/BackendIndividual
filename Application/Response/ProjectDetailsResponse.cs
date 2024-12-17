namespace Application.Response
{
    public class ProjectDetailsResponse
    {
        public ProjectResponse Data { get; set; }
        public List<InteractionResponse> Interactions { get; set; }
        public List<TaskResponse> Tasks { get; set; }

    }
}
