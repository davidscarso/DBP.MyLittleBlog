using System;
using System.Collections.Generic;
using System.Text;
using DBP.MyLittleBlog.Localization;
using Volo.Abp.Application.Services;

namespace DBP.MyLittleBlog;

/* Inherit your application services from this class.
 */
public abstract class MyLittleBlogAppService : ApplicationService
{
    protected MyLittleBlogAppService()
    {
        LocalizationResource = typeof(MyLittleBlogResource);
    }
}
