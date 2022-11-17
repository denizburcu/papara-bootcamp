namespace OwnerProject.Services.Contract
{
    public class OwnerDto
    {
        public int Guid { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Description { get; set; }
        public string? OwnerType { get; set; }
    }
}