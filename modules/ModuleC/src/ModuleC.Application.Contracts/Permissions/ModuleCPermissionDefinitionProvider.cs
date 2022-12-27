using ModuleC.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ModuleC.Permissions;

public class ModuleCPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ModuleCPermissions.GroupName, L("Permission:ModuleC"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ModuleCResource>(name);
    }
}
