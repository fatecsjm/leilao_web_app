using Microsoft.AspNet.Identity.EntityFramework;

namespace Projeto.Models
{
    public class Role : IdentityRole
    {
        public Role(): base() { }
        public Role(string rolename)
            : base(rolename)
        {
        }
    }
}