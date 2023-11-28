using System.ComponentModel.DataAnnotations;

namespace Gatherama.Shared
{
    public class PersonDto
    {
        public string? Id { get; set; }
        public string? firstName { get; set; }
        //[Required(ErrorMessage = "Last Name is required")]
        //[StringLength(20, MinimumLength = 3, ErrorMessage = "Last Name cannot have less than 3 characters and more than 20 characters in length")]
        public string? lastName { get; set; }
        public string? username { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
    }
}