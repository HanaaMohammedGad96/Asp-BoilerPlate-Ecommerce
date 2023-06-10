using System.Threading.Tasks;
using Abp.Application.Services;
using MyEcommerce.Sessions.Dto;

namespace MyEcommerce.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
