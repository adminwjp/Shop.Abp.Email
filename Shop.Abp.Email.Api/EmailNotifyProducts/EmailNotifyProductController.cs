using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.EmailNotifyProducts.Dtos;

namespace Shop.EmailNotifyProducts
{

    // [Route("api/v{version:apiVersion}/admin/[controller]")]
    [Route("api/v{version:apiVersion}/admin/email_notify_product")]
    public class EmailNotifyProductController : BaseController<EmailNotifyProductAppService, IEmailNotifyProductRepository, EmailNotifyProduct,
        CreateEmailNotifyProductInput, UpdateEmailNotifyProductInput, EmailNotifyProductInput,EmailNotifyProductOutput>
    {
        public EmailNotifyProductController(EmailNotifyProductAppService service) : base(service)
        {
            this.service = service;
        }
    }
}
