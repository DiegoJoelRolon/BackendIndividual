namespace Application.Response
{
    public class ProjectResponse
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public ClientResponse Client { get; set; }
        public GenericResponse CampaignType { get; set; }

    }
}
