using System;
using System.Collections.Generic;
using System.Text;
using New3C_Model;
using New3C_DataService;
using New3C_Service;

namespace New3C_Servicelmpl
{
    public class ItemCategoryServicelmpl:ItemCategoryService
    {
        private readonly ItemCategoryDataService _itemCategoryDataService;

        public ItemCategoryServicelmpl(ItemCategoryDataService ItemCategoryDataService)
        {
            _itemCategoryDataService = ItemCategoryDataService;
        }

        public ItemCategory GetItemCategory()
        {
            return _itemCategoryDataService.GetItemCategoryList();
        }

    }
}
