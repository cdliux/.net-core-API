using System;
using System.Collections.Generic;
using System.Text;
using New3C_Model;
using New3C_DataService;
using New3C_Service;

namespace New3C_Servicelmpl
{
    public class ShoppingCartServicelmpl:ShoppingCartService
    {
        private readonly ShoppingCartDataService _shoppingCartDataService;

        public ShoppingCartServicelmpl(ShoppingCartDataService shoppingCartDataService)
        {
            _shoppingCartDataService = shoppingCartDataService;
        }

       public bool AddToShoopingCart(ShoppingCart cart)
        {
            return _shoppingCartDataService.AddToShoopingCart(cart);
        }

        public List<ShoppingCartList> GetUserSHoppingCart(string UserID)
        {
           var shoppingCartList =  _shoppingCartDataService.GetShoppingCartList(UserID);

            var idCount = 0;
            //价格计算
           foreach(var item in shoppingCartList)
            {
                item.ID = idCount;
                idCount++;
                item.Price = item.Amount * item.Price;
            }
            return shoppingCartList;
        }
    }
}
