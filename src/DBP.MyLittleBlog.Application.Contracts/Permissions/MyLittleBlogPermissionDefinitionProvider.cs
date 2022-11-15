using DBP.MyLittleBlog.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace DBP.MyLittleBlog.Permissions;

public class MyLittleBlogPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(MyLittleBlogPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(MyLittleBlogPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<MyLittleBlogResource>(name);
    }
}
