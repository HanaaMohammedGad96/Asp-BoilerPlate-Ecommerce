using System.Collections.Generic;
using MyEcommerce.Roles.Dto;

namespace MyEcommerce.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
