using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.EmailNotifyProducts.Dtos
{
    /// <summary>
    ///添加 邮件 通知商品  实体
    /// </summary>
    [AutoMap(typeof(EmailNotifyProduct))]
    public class CreateEmailNotifyProductInput: BaseEmailNotifyProductInput
    {
    }
}
