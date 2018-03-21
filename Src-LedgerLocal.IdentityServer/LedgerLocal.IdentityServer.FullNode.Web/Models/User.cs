using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace UserManagement.Models
{
    public class User: IdentityUser
    {
        public string CustomerId { get; set; }
    }
}
