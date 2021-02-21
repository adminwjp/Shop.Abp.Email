using System.Collections.Generic;
using Abp.AspNetCore.Mvc.Controllers;
using Abp.Authorization;
using Abp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Services;
using Shop.Application.Services.Dtos;
using Shop.Domain.Entities;
using Shop.Domain.Repositories;
using Utility.Enums;
using Utility.Response;

namespace Shop
{
    [Route("api/v{version:apiVersion}/admin/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [DontWrapResult]//abp 改变默认封装的返回格式
    //[AbpAuthorize]
    public abstract class BaseController<Service, Repository, Entity, CreateInput, UpdateInput, Input,Dto > : AbpController
        where Service: BaseAppService<Repository, Entity, CreateInput, UpdateInput, Input,Dto>
         where Repository : IBaseRepository<Entity>
        where CreateInput : class
        where UpdateInput : class, IUpdateInput
        where Dto : class
        where Input : class
        where Entity : BaseEntity
    {
        protected Service service;
        public BaseController(Service service)
        {
            this.service = service;
        }
        /// <summary>
        /// 添加 
        /// </summary>
        /// <param name="create"></param>
        /// <returns></returns>
        [HttpPost("insert")]
        public IResponseApi Insert([FromBody] CreateInput create)
        {
            int res = service.Insert(create);
            return ResponseApi.Create(Language.Chinese, res > 0 ? Code.AddSuccess : Code.AddFail);
        }
        /// <summary>
        /// 修改 
        /// </summary>
        /// <param name="create"></param>
        /// <returns></returns>
        [HttpPost("update")]
        public IResponseApi Update([FromBody] UpdateInput update)
        {
            int res = service.Update(update);
            return ResponseApi.Create(Language.Chinese, res > 0 ? Code.ModifySuccess : Code.ModifyFail);
        }
        [HttpGet("delete/{id}")]
        public IResponseApi Delete(string id)
        {
            service.Delete(id);
            return ResponseApi.Create(Language.Chinese, Code.DeleteSuccess);
        }
        [HttpPost("delete_list")]
        public IResponseApi DeleteList([FromBody] Utility.Domain.Entities.DeleteEntity<string> ids)
        {
            service.Delete(ids.Ids);
            return ResponseApi.Create(Language.Chinese, Code.DeleteSuccess);
        }
        [HttpPost("find")]
        public ResponseApi<IList<Dto>> Find([FromBody] Input entity)
        {
            var res = service.Find(entity);
            return ResponseApi<IList<Dto>>.Create(Language.Chinese, Code.QuerySuccess).SetData(res);
        }
        [HttpPost("find_by_page/{page}/{size}")]
        public ResponseApi<IList<Dto>> FindByPage([FromBody] Input entity, int page = 1, int size = 10)
        {
            var res = service.FindByPage(entity, page, size);
            return ResponseApi<IList<Dto>>.Create(Language.Chinese, Code.QuerySuccess).SetData(res);
        }
        [HttpPost("count")]
        public int Count([FromBody] Input entity)
        {
            int res = service.Count(entity);
            return res;
        }
    }
}
