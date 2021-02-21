using Abp.ObjectMapping;
using Shop.Emails.Dtos;
using Microsoft.Extensions.Logging;
using Shop.Application.Services;

namespace Shop.Emails
{
    /// <summary>
    /// 邮件 服务 
    /// </summary>
    public class EmailAppService : BaseAppService<IEmailRepository, Email, CreateEmailInput, UpdateEmailInput,
        EmailInput,EmailOutput >
    {
        public EmailAppService(IEmailRepository repository, IObjectMapper objectMapper, ILogger<EmailAppService> logger) : base(repository, objectMapper, null, null, logger, null)
        {

        }
        //public EmailAppService(IEmailRepository repository, IObjectMapper objectMapper,
        //     ICacheManager cacheManager, IAbpRedisCacheDatabaseProvider abpRedisCacheDatabaseProvider,
        //    ILogger<EmailAppService> logger, IEmailSender emailSender) : base(repository, objectMapper, cacheManager, abpRedisCacheDatabaseProvider, logger,emailSender)
        //{
        //}
        

    }
}
