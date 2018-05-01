using System;
using System.Collections.Generic;
using System.Text;
using New3C_Model;

namespace New3C_DataService
{
    public interface IItemListSearchDataService
    {
        List<Item> ItemListQuery(ItemQueryCondition condition);
    }
}
