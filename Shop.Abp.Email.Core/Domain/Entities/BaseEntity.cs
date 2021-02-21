﻿using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    /// <summary>
    /// 基类 实体
    /// </summary>
    public class BaseEntity : IEntity<string>, IHasCreationTime, IHasModificationTime, IHasDeletionTime
    {
        /// <summary>
        /// 主键 Specified key was too long; max key length is 767 bytes
        /// </summary>
       	[Column("id")]
        [System.ComponentModel.DataAnnotations.StringLength(36)]
        public virtual string Id { get; set; }
        /// <summary>
        /// 创建 时间 datetime(6) mysql 5.5 不支持 ; datetime mysql 支持
        /// </summary>
        [System.ComponentModel.DataAnnotations.Schema.Column("creation_time"
#if MySql5_5
            , TypeName = "datetime"
#endif
            )]
        public virtual DateTime CreationTime { get; set; }
        /// <summary>
        /// 修改 时间
        /// </summary>
        [System.ComponentModel.DataAnnotations.Schema.Column("last_modification_time"
#if MySql
            , TypeName = "datetime"
#endif
            )]
        public virtual DateTime? LastModificationTime { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        [System.ComponentModel.DataAnnotations.Schema.Column("deletion_time"
#if MySql5_5
            , TypeName = "datetime"
#endif
            )]
        public virtual DateTime? DeletionTime { get; set; }
        /// <summary>
        /// 软删除 标识
        /// </summary>
        [Column("is_deleted")]
        public virtual bool IsDeleted { get; set; }

        public virtual bool IsTransient()
        {
            return true;
        }
    }
}
