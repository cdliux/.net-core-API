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
    [Route("api/ItemSearch")]
    public class ItemSearchController : Controller
    {
        private readonly IItemListSearchService _itemListSearchService;

        public ItemSearchController(IItemListSearchService ItemListSearchService)
        {
            _itemListSearchService = ItemListSearchService;
        }

        [HttpPost]
        public List<Item> ItemListQuery([FromBody]ItemQueryCondition condition)
        {
            return _itemListSearchService.ItemListQuery(condition);
        }
    }
}