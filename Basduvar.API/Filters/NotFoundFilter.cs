using Basduvar.API.DTOs;
using Basduvar.Core.Models;
using Basduvar.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basduvar.API.Filters
{
    public class NotFoundFilter : ActionFilterAttribute
    {
        private readonly IService<Product> _service;
        public NotFoundFilter(IService<Product> Service)
        {
            _service = Service;
        }
        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();
            var product = await _service.GetByIdAsync(id);
            if (product!=null)
            {
                await next();
            }
            else
            {
                ErrorDto errorDto = new ErrorDto();
                errorDto.Status = 404;
                errorDto.Errors.Add($"id'si {id} olan ürün veritabanında bulunamadı");
                context.Result = new NotFoundObjectResult(errorDto);
            }
        }
    }
}
