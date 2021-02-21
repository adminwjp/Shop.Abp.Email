using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Shop.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.EmailNotifyProducts
{
	/// <summary>
	///通知商品  邮件  用于订单 (发送订单 取消订单 订单失败) 广告(推荐商品)
	/// </summary>
	[System.ComponentModel.DataAnnotations.Schema.Table("t_email_notify_product")]
	public class EmailNotifyProduct:BaseEntity
    {
		/// <summary>
		/// 状态
		/// </summary>
		[Column("status")]
		[StringLength(1)]
		public virtual string Status { get; set; }
		/// <summary>
		/// 通知时间 mysql 5.0 几 不支持 datetime(6) 其他版本 支持 数据库版本 
		/// </summary>
		[System.ComponentModel.DataAnnotations.Schema.Column("notify_date"
#if MySql5_5
			, TypeName = "datetime"
#endif
			)]
		public virtual DateTime NotifyDate { get; set; }
		/// <summary>
		/// 订单 id
		/// </summary>
		[Column("order_id")]
		[StringLength(36)]
		public virtual string OrderID { get; set; }
		/// <summary>
		/// 商品名称
		/// </summary>
		[Column("product_name")]
		[StringLength(50)]
		public virtual string ProductName { get; set; }
		/// <summary>
		/// 回复邮件
		/// </summary>
		[Column("receive_email")]
		[StringLength(200)]
		public virtual string ReceiveEmail { get; set; }
		/// <summary>
		/// 产品 id
		/// </summary>
		[Column("product_id")]
		[StringLength(36)]
		public virtual string ProductID { get; set; }
		/// <summary>
		/// 发送失败次数
		/// </summary>
		[Column("send_failure_count")]
		public virtual int SendFailureCount { get; set; }
		/// <summary>
		/// 账户
		/// </summary>
		[Column("account")]
		[StringLength(20)]
		public virtual string Account { get; set; }

	}
}
