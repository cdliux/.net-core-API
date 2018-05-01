using System;
using System.Collections.Generic;
using System.Text;
using New3C_Model;
using New3C_Service;
using New3C_DataService;

namespace New3C_Servicelmpl
{
    public class ItemListSearchServicelmpl:IItemListSearchService
    {
        private readonly IItemListSearchDataService _itemSearchDataService;

        public ItemListSearchServicelmpl(IItemListSearchDataService ItemSearchDataService)
        {
            _itemSearchDataService = ItemSearchDataService;
        }
        public List<Item> ItemListQuery(ItemQueryCondition condition)
        {
            return _itemSearchDataService.ItemListQuery(condition);
        }
    }
}
