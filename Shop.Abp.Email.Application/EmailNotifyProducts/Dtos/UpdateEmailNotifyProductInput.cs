using Abp.AutoMapper;
using Shop.Application.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.EmailNotifyProducts.Dtos
{
    /// <summary>
    ///修改 邮件 通知商品  实体
    /// </summary>
    [AutoMap(typeof(EmailNotifyProduct))]
    public class UpdateEmailNotifyProductInput: BaseEmailNotifyProductInput, IUpdateInput
    {
        /// <summary>
        /// 主键
        /// </summary>
        public virtual string Id { get; set; }
    }
}
