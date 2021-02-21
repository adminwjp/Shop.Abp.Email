using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Emails.Dtos
{
    /// <summary>
    ///添加 邮件 实体
    /// </summary>
    [AutoMap(typeof(Email))]
    public class CreateEmailInput: BaseEmailInput
    {
    }
}
