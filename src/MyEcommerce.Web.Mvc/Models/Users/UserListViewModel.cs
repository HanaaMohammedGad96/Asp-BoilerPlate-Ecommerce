using System.Collections.Generic;
using MyEcommerce.Roles.Dto;

namespace MyEcommerce.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
