using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Shop.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Emails
{
	/// <summary>
	/// 邮件 实体 用于登录 注册 找回密码 
	/// </summary>
	[System.ComponentModel.DataAnnotations.Schema.Table("t_mail")]
	public class Email:BaseEntity
    {
		/// <summary>
		/// 新邮件 即邮箱
		/// </summary>
		[Column("email")]
		[StringLength(20)]
		public virtual string NewEmail { get; set; }
		/// <summary>
		/// 发送状态 y success n fail
		/// </summary>
		[Column("status")]
		[StringLength(1)]
		public virtual string Status { get; set; }
		/// <summary>
		/// 账户
		/// </summary>
		[Column("account")]
		[StringLength(20)]
		public virtual string Account { get; set; }
		/// <summary>
		/// 地址
		/// </summary>
		[Column("url")]
		[StringLength(100)]
		public virtual string Url { get; set; }
		/// <summary>
		/// 开始 时间
		/// </summary>
		[Column("start_time"
#if MySql5_5
			, TypeName = "datetime"
#endif
			)]
		public virtual DateTime? StartTime { get; set; }
		/// <summary>
		/// 状态 
		/// </summary>
		[Column("suc")]
		public virtual bool Suc { get; set; }

		/// <summary>
		/// 标识
		/// </summary>
		[Column("flag")]
		public virtual EmailFlag Flag { get; set; }

		/// <summary>
		/// 结束 时间
		/// </summary>
		[Column("end_time"
#if MySql5_5
			, TypeName = "datetime"
#endif
			)]
		public virtual DateTime? EndTime { get; set; }

	}

	/// <summary>
	/// 邮件标识
	/// </summary>
	public enum EmailFlag
    {
		None=0x0,
		Login=0x1,
		Register=0x2,
		ForgetPwd=0x3
    }
}
