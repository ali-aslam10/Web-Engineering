using Microsoft.AspNetCore.Identity;

namespace Lab_project.Models
{
    public class MyUser : IdentityUser
    {
        public string  fname { get; set; }
        public string lname { get; set; }
    }
}
