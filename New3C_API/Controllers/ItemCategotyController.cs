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
    [Route("api/ItemCategoty")]
    public class ItemCategotyController : Controller
    {
        private readonly ItemCategoryService _itemCategoryService;

        public ItemCategotyController(ItemCategoryService ItemCategoryService)
        {
            _itemCategoryService = ItemCategoryService;
        }


        [HttpGet]
        public ItemCategory GetItemCateGory()
        {
            return _itemCategoryService.GetItemCategory();
        }
    }
}