namespace Application.Response
{
    public class InteractionResponse
    {
        public Guid Id { get; set; }
        public string Notes { get; set; }
        public DateTime Date { get; set; }
        public Guid ProjectID { get; set; }
        public GenericResponse InteractionType { get; set; }

    }
}
