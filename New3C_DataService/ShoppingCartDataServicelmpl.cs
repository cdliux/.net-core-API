using System;
using System.Collections.Generic;
using System.Text;
using VIC.DataAccess.Abstraction;
using New3C_DataService;
using New3C_Model;

namespace New3C_DataServicelmpl
{
   public class ShoppingCartDataServicelmpl:ShoppingCartDataService
    {
        private static IDbManager _DB;

        public ShoppingCartDataServicelmpl(IDbManager dbManager)
        {
            _DB = dbManager;
        }

        public bool AddToShoopingCart(ShoppingCart cart)
        {
            var cmd = _DB.GetCommand("AddToShoppingCart");
            var result = cmd.ExecuteNonQuery(new { ItemNumber = cart.ItemNumber,
                ItemAmount = cart.ItemAmount,
                UserID =cart.UserID,
                CategoryPicID =cart.CategoryPicID });
            if (result >= 1)
                return true;
            else
                return false;
        }

        public List<ShoppingCartList> GetShoppingCartList(string UserID)
        {
            var cmd = _DB.GetCommand("GetShoppingCartList");
            var result = cmd.ExecuteEntityList<ShoppingCartList>(new { Id = UserID });
            return result;
        }
    }
}
