namespace EasyHR.DemoFormApp.Entities.DTOs
{
    public class FormListDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
