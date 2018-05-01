using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using New3C_Model;
using New3C_Service;

namespace New3C_API.Controllers
{
    [Produces("application/json")]
    [Route("api/ShippingSetting")]
    public class ShippingSettingController : Controller
    {
        private readonly IItemShippingSettingServices _itemShippingSettingServices;

        public ShippingSettingController(IItemShippingSettingServices ItemShippingSettingServices)
        {
            _itemShippingSettingServices = ItemShippingSettingServices;
        }
        

        /// <summary>
        /// 保存商品配送信息
        /// </summary>
        /// <param name="shippingSetting"></param>
        /// <returns></returns>
        [HttpPost]
        public bool SaveItemShippingSetting([FromBody]ItemShippingSetting shippingSetting)
        {
            var result = _itemShippingSettingServices.SaveItemShippingSetting(shippingSetting);
            return result;
            //if(result)
            //   return Ok();

            //return StatusCode(400);
        }
    }
}