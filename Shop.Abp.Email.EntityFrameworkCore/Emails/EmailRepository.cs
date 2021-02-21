using Abp.EntityFrameworkCore;
using Shop.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Emails
{
    /// <summary>
    /// 邮件 仓库 
    /// </summary>
    public class EmailRepository:ShopRepositoryBase<Email>,IEmailRepository
    {
        public EmailRepository(IDbContextProvider<EmailDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}
