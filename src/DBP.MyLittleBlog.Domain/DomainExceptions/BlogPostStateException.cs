using Microsoft.Extensions.Logging;
using System;
using Volo.Abp;

namespace DBP.MyLittleBlog.DomainExceptions
{
    public class BlogPostStateException : BusinessException, IUserFriendlyException
    {
        public BlogPostStateException(string code = null, string message = null, string details = null, Exception innerException = null, LogLevel logLevel = LogLevel.Warning)
            : base(code, message, details, innerException, logLevel)
        {
        }
    }
}
