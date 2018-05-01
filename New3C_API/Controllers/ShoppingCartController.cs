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
    [Route("api/ShoppingCart")]
    public class ShoppingCartController : Controller
    {
        private readonly ShoppingCartService _shoppingCartService;
        public ShoppingCartController(ShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        [HttpPost]
        public bool AddToShoppingCart([FromBody]ShoppingCart cart)
        {
            return _shoppingCartService.AddToShoopingCart(cart);
        }

        [HttpGet("{UserID}")]
        public List<ShoppingCartList> GetUserShoppingCart(string  UserID)
        {
            return _shoppingCartService.GetUserSHoppingCart(UserID);
        }
    }
}