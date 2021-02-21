using Abp.ObjectMapping;
using Microsoft.Extensions.Logging;
using Shop.EmailNotifyProducts.Dtos;
using Shop.Application.Services;
using Abp.Domain.Uow;

namespace Shop.EmailNotifyProducts
{
    /// <summary>
    /// 邮件通知 服务 
    /// </summary>
    public class EmailNotifyProductAppService : BaseAppService<IEmailNotifyProductRepository, EmailNotifyProduct, CreateEmailNotifyProductInput, UpdateEmailNotifyProductInput,
       EmailNotifyProductInput, EmailNotifyProductOutput>
    {
        public EmailNotifyProductAppService(IEmailNotifyProductRepository repository, IObjectMapper objectMapper, ILogger<EmailNotifyProductAppService> logger) : base(repository, objectMapper, null, null, logger, null)
        {

        }
        //public EmailNotifyProductAppService(IEmailNotifyProductRepository repository, IObjectMapper objectMapper,
        //   ICacheManager cacheManager, IAbpRedisCacheDatabaseProvider abpRedisCacheDatabaseProvider,
        //    ILogger<EmailNotifyProductAppService> logger, IEmailSender emailSender) : base(repository, objectMapper, cacheManager, abpRedisCacheDatabaseProvider, logger,emailSender)
        //{
        //}


    }
}
