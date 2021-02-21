using Abp.Domain.Repositories;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.EmailNotifyProducts
{
    /// <summary>
    /// 邮件通知 仓库 
    /// </summary>
    public interface IEmailNotifyProductRepository : IBaseRepository<EmailNotifyProduct>
    {
    }
}
