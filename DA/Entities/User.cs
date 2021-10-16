using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DA.Entities
{
    public class User : IdentityUser
    {
        public virtual ICollection<Deal> CreatedDeals { get; set; }
        public virtual ICollection<Deal> PerformedDeals { get; set; }
    }
}