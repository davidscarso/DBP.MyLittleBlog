using Volo.Abp.Reflection;

namespace ModuleB.Permissions;

public class ModuleBPermissions
{
    public const string GroupName = "ModuleB";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(ModuleBPermissions));
    }
}
