using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTemplate.Models.Authentication
{
    public static class UserRoles
    {
        public const string Admin = "Admin";
        public const string StudentAdmin = "StudentAdmin";
        public const string User = "User";
    }
}
