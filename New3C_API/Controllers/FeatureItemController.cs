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
    [Route("api/ItemImage")]
    public class FeatureItemController : Controller
    {
        private readonly FeatureItemService _featureItemService;

        public FeatureItemController(FeatureItemService featureItemService)
        {
            _featureItemService = featureItemService;
        }

        [HttpGet("{Actions}")]
        public List<Item> Get(string Actions)
        {

            return _featureItemService.GetFeatureList(Actions);

        }


    }
}