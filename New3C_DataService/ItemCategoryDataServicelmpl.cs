using System;
using System.Collections.Generic;
using System.Text;
using New3C_Model;
using New3C_DataService;
using VIC.DataAccess.Config;
using VIC.DataAccess.Abstraction;

namespace New3C_DataServicelmpl
{
    public class ItemCategoryDataServicelmpl:ItemCategoryDataService
    {
        private readonly IDbManager _DB;

        public ItemCategoryDataServicelmpl(IDbManager dbManager)
        {
            _DB = dbManager;
        }


        public ItemCategory GetItemCategoryList()
        {
            var command = _DB.GetCommand("GetItemDomainLsit");
            var command2 = _DB.GetCommand("GetItemCategoryLsit");
            var command3 = _DB.GetCommand("GetItemSubCategoryLsit");
            var result = command.ExecuteEntityList<Domain>();
            var result2 = command2.ExecuteEntityList<Category>();
            var result3 = command3.ExecuteEntityList<SubCategory>();
            var ItemCategory = new ItemCategory()
            {
                DomainList = result,
                CategoryList = result2,
                SubCategoryList = result3
            };

            return ItemCategory;
        }
    }
}
