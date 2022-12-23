using ModuleB.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ModuleB.Permissions;

public class ModuleBPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ModuleBPermissions.GroupName, L("Permission:ModuleB"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ModuleBResource>(name);
    }
}
