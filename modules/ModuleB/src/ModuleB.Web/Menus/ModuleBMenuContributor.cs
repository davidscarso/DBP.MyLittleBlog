using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace ModuleB.Web.Menus;

public class ModuleBMenuContributor : IMenuContributor
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
        context.Menu.AddItem(new ApplicationMenuItem(ModuleBMenus.Prefix, displayName: "ModuleB", "~/ModuleB", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
