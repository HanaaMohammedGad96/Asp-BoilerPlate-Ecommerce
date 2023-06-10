using System.Collections.Generic;
using MyEcommerce.Roles.Dto;

namespace MyEcommerce.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}