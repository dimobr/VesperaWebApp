namespace VesperaWebApp.Models
{
    public class EmailEntityModel : BaseEntity
    {
        public string? Subject { get; set; }
        public string? EmailBody { get; set; }
    }
}
