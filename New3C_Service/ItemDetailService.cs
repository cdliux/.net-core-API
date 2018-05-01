using System;
using System.Collections.Generic;
using System.Text;
using New3C_Model;

namespace New3C_Service
{
    public interface ItemDetailService
    {
        List<ItemCategoryPrice> GetItemCategoryPrice(string ItemNumber);

        int CreateItem(ItemCreation NewItem);

    }
}
