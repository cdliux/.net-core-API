using System;
using System.Collections.Generic;
using System.Text;
using New3C_Model;

namespace New3C_DataService
{
    public interface ItemDetailDataService
    {
        List<ItemCategoryPrice> GetItemCategoryPrice(string ItemNumber);

        int CreateNewItem(ItemCreation NewItem);

        bool AddItemImage(ItemCreation NewItem);

        bool AddItemSubcategory(ItemCreation NewItem);

        //List<Item> SearchItem();
    }
}
