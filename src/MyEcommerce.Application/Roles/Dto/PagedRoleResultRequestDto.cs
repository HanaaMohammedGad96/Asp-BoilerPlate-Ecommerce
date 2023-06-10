using Abp.Application.Services.Dto;

namespace MyEcommerce.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

