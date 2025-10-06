using EasyHR.DemoFormApp.Entities.Base;

namespace EasyHR.DemoFormApp.Entities.Entities
{
    public class Form : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Fullname => $"{FirstName} {LastName}";
        public DateTime BirthDate { get; set; }
    }
}
