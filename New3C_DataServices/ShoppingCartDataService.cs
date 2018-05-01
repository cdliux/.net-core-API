using System;
using System.Collections.Generic;
using System.Text;
using New3C_Model;

namespace New3C_DataService
{
    public interface ShoppingCartDataService
    {
        bool AddToShoopingCart(ShoppingCart cart);
        List<ShoppingCartList> GetShoppingCartList(string UserID);
    }
}
