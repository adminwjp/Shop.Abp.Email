using Abp.Domain.Repositories;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Emails
{
    /// <summary>
    /// 邮件 仓库 
    /// </summary>
    public interface IEmailRepository : IBaseRepository<Email>
    {
    }
}
