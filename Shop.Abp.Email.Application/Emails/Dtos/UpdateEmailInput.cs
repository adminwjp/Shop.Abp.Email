using Abp.AutoMapper;
using Shop.Application.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Emails.Dtos
{
    /// <summary>
    ///修改 邮件 实体
    /// </summary>
    [AutoMap(typeof(Email))]
    public class UpdateEmailInput: BaseEmailInput, IUpdateInput
    {
        /// <summary>
        /// 主键
        /// </summary>
        public virtual string Id { get; set; }
    }
}
