using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using New3C_Service;
using New3C_Model;

namespace New3C_API.Controllers
{
    [Produces("application/json")]
    [Route("api/ItemDetail")]
    public class ItemDetailController : Controller
    {
        private readonly ItemDetailService _itemDetailService;

        public ItemDetailController(ItemDetailService itemDetailService)
        {
            _itemDetailService = itemDetailService;
        }

        [HttpGet("{ItemNumber}")]
        public List<ItemCategoryPrice> GetItemCategoryPriceList(string ItemNumber)
        {
            return _itemDetailService.GetItemCategoryPrice(ItemNumber);
        }

        [HttpPost]
        public int CreateItem([FromBody] ItemCreation form)
        {

            return _itemDetailService.CreateItem(form);
        }
    }
}