using Microsoft.AspNetCore.Identity;

namespace Lab_project_2.Models
{
    public class MyUser:IdentityUser
    {
        public string department { get; set; }
    }
}
