using System.Threading.Tasks;
using MyEcommerce.Configuration.Dto;

namespace MyEcommerce.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
