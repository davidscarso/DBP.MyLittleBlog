using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace ModuleC.Web.Menus;

public class ModuleCMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        //Add main menu items.
        context.Menu.AddItem(new ApplicationMenuItem(ModuleCMenus.Prefix, displayName: "ModuleC", "~/ModuleC", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
