using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Emails.Dtos
{
	/// <summary>
	///查询 邮件 实体 
	/// </summary>
	[AutoMap(typeof(Email))]
	public class EmailInput
    {
		/// <summary>
		/// 新邮件
		/// </summary>
		public virtual string NewEmail { get; set; }
		/// <summary>
		/// 发送状态
		/// </summary>
		public virtual string Status { get; set; }
		/// <summary>
		/// 账户
		/// </summary>
		public virtual string Account { get; set; }
		/// <summary>
		/// 地址
		/// </summary>
		public virtual string Url { get; set; }
		/// <summary>
		/// 开始 时间
		/// </summary>
		public virtual DateTime? StartTime { get; set; }
		/// <summary>
		/// 状态
		/// </summary>
		public virtual bool Suc { get; set; }
		/// <summary>
		/// 邮件标识
		/// </summary>
		public virtual int Flag { get; set; }
		/// <summary>
		/// 结束 时间
		/// </summary>
		public virtual DateTime? EndTime { get; set; }
	}
}
