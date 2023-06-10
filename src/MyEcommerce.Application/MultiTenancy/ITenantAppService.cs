using Abp.Application.Services;
using MyEcommerce.MultiTenancy.Dto;

namespace MyEcommerce.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

