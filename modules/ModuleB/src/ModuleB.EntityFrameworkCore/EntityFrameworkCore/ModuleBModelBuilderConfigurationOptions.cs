using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace ModuleB.EntityFrameworkCore
{
    public class ModuleBModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public ModuleBModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(tablePrefix, schema)
        {

        }
    }
}