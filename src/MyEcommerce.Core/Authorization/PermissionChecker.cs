using Abp.Authorization;
using MyEcommerce.Authorization.Roles;
using MyEcommerce.Authorization.Users;

namespace MyEcommerce.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
