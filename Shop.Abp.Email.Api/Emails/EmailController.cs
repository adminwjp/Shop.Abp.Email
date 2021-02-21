using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Emails.Dtos;

namespace Shop.Emails
{
    
    [Route("api/v{version:apiVersion}/admin/[controller]")]
    public class EmailController : BaseController<EmailAppService, IEmailRepository, Email, CreateEmailInput, UpdateEmailInput,
       EmailInput,EmailOutput >
    {
        public EmailController(EmailAppService service) : base(service)
        {
            this.service = service;
        }
    }
}
