using Volo.Abp.Settings;

namespace DBP.MyLittleBlog.Settings;

public class MyLittleBlogSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(MyLittleBlogSettings.MySetting1));
    }
}
