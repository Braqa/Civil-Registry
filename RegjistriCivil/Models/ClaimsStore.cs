using System.Collections.Generic;
using System.Security.Claims;

namespace RegjistriCivil.Models
{
    public static class ClaimsStore
    {
        public static List<Claim> AllClaims = new List<Claim>()
        {
            new Claim("Create Id Card", "Create Id Card"),
            new Claim("Edit Id Card", "Edit Id Card"),
            new Claim("Delete Id Card", "Delete Id Card"),
            new Claim("Create Passport", "Create Passport"),
            new Claim("Edit Passport", "Edit Passport"),
            new Claim("Delete Passport", "Delete Passport"),
            new Claim("Create Certificate", "Create Certificate"),
            new Claim("Edit Certificate", "Edit Certificate"),
            new Claim("Delete Certificate", "Delete Certificate"),
            new Claim("Create Role", "Create Role"),
            new Claim("Edit Role", "Edit Role"),
            new Claim("Delete Role", "Delete Role"),
            new Claim("Create User", "Create User"),
            new Claim("Edit User", "Edit User"),
            new Claim("Delete User", "Delete User"),
        };
    }
}
