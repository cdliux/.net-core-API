using System;
using System.Collections.Generic;
using System.Text;
using New3C_Model;
using New3C_DataService;
using VIC.DataAccess.Abstraction;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using VIC.DataAccess.MSSql;
using VIC.DataAccess.Config;

namespace New3C_DataServicelmpl
{
    public class FeatureItemDataServicelmpl:FeatureItemDataService
    {
        private static IDbManager _DB;

        public FeatureItemDataServicelmpl(IDbManager dbManager)
        {
            _DB = dbManager;
        }

        public List<Item> GetFeatureItemList(string Action)
        {
            //导航条
            if(Action=="navBar")
            {
                var command = _DB.GetCommand("GetNavItemList");
                List<Item> navItemList = command.ExecuteEntityList<Item>();
                return navItemList;
            }
            //今日大促
            else if (Action == "promotion")
            {
                var command = _DB.GetCommand("GetFeatureItemList");
                List<Item> featureItemList = command.ExecuteEntityList<Item>();
                return featureItemList;
            }
            //今日热销
            else if (Action == "hot")
            {
                var command = _DB.GetCommand("GetFeatureItemList");
                List<Item> featureItemList = command.ExecuteEntityList<Item>();
                return featureItemList;
            }
            //商品图片集合
            else if (Action == "item")
            {
                var command = _DB.GetCommand("GetFeatureItemList");
                List<Item> featureItemList = command.ExecuteEntityList<Item>();
                return featureItemList;
            }
            //商品详细集合
            else if (Action == "itemDetail")
            {
                var command = _DB.GetCommand("GetFeatureItemList");
                List<Item> featureItemList = command.ExecuteEntityList<Item>();
                return featureItemList;
            }

            return null;
        }
    }
}
