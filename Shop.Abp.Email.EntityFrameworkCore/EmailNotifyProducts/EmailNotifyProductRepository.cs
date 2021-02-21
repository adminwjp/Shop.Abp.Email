using Abp.EntityFrameworkCore;
using Shop.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.EmailNotifyProducts
{
    /// <summary>
    /// 邮件通知 仓库 
    /// </summary>
    public class EmailNotifyProductRepository:ShopRepositoryBase<EmailNotifyProduct>, IEmailNotifyProductRepository
    {
        public EmailNotifyProductRepository(IDbContextProvider<EmailDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}
