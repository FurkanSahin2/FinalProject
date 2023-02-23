using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] // --> ATTRIBUTE
    public class ProductsController : ControllerBase
    {
        // Swagger
        // Loosely coupled --> Gevşek bağımlılık / Yani, bağımlılığı var ama soyut bir nesneye bağımlı.
        // naming convention --> İsimlendirme standartı
        // IoC Container --> Inversion of control (Değişimin kontrolü)

        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getbyid")]

        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("add")]

        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //[HttpPost("delete")]

        //public IActionResult Delete(Product product)
        //{
        //    var result = _productService.Delete(product);
        //    if (result.Success == true)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}
    }
}
