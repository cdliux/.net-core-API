using System;
using System.Collections.Generic;
using System.Text;
using New3C_Model;
using New3C_DataService;
using VIC.DataAccess.Abstraction;

namespace New3C_DataServicelmpl
{
    public class ItemListSearchDataServicelmpl:IItemListSearchDataService
    {
        private readonly IDbManager _DB;

        public ItemListSearchDataServicelmpl(IDbManager db)
        {
            _DB = db;
        }

        public List<Item> ItemListQuery(ItemQueryCondition condition)
        {
            //使用拼接SQL查询
            var command = _DB.GetCommand("ItemListQuery");
            var result = command.ExecuteEntityList<Item>(new{ ItemNumber = condition.ItemNumber
                ,ItemName=condition.ItemName
                ,ItemStatus=condition.ItemStatus
            });

            return result;
        }
    }
}
