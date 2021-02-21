using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.EmailNotifyProducts.Dtos
{
	/// <summary>
	///查询 邮件 通知商品  实体 
	/// </summary>
	[AutoMap(typeof(EmailNotifyProduct))]
	public class EmailNotifyProductInput
    {
		/// <summary>
		/// 状态
		/// </summary>
		public virtual string Status { get; set; }
		/// <summary>
		/// 通知时间
		/// </summary>
		public virtual DateTime NotifyDate { get; set; }
		/// <summary>
		/// 商品名称
		/// </summary>
		public virtual string ProductName { get; set; }
		/// <summary>
		/// 回复邮件
		/// </summary>
		public virtual string ReceiveEmail { get; set; }
		/// <summary>
		/// 产品 id
		/// </summary>
		public virtual string ProductID { get; set; }
		/// <summary>
		/// 发送失败次数
		/// </summary>
		public virtual int SendFailureCount { get; set; }
		/// <summary>
		/// 账户
		/// </summary>
		public virtual string Account { get; set; }
	}
}
