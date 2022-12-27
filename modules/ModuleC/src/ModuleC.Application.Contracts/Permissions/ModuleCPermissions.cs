using Volo.Abp.Reflection;

namespace ModuleC.Permissions;

public class ModuleCPermissions
{
    public const string GroupName = "ModuleC";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(ModuleCPermissions));
    }
}
