using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Services.Dtos
{
    public interface IUpdateInput
    {
         /// <summary>
          /// 主键
          /// </summary>
         string Id { get; set; }
    }
}
