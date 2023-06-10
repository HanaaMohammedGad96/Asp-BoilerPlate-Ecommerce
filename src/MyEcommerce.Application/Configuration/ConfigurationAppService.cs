using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using MyEcommerce.Configuration.Dto;

namespace MyEcommerce.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : MyEcommerceAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
