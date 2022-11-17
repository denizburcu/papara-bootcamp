using System.Security.Cryptography.Xml;
using Microsoft.AspNetCore.Mvc;

namespace Owner.API
{
    public class Owner
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }

    }
}