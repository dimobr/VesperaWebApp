namespace VesperaWebApp.Models
{
    public class ImageEntityModel : BaseEntity
    {
        public string? Description { get; set; }
        public byte[]? Image { get; set; } 
    }
}
