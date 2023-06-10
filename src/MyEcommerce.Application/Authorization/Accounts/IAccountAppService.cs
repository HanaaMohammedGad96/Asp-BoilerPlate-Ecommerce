using System.Threading.Tasks;
using Abp.Application.Services;
using MyEcommerce.Authorization.Accounts.Dto;

namespace MyEcommerce.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
