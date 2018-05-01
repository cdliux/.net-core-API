using System;
using System.Collections.Generic;
using System.Text;
using New3C_Model;
using New3C_DataService;
using VIC.DataAccess.Abstraction;

namespace New3C_DataServicelmpl
{
    public class ItemShippingSettingDataSevicelmpl:IItemShippingSettingDataService
    {
        private readonly IDbManager _DB;

        public ItemShippingSettingDataSevicelmpl(IDbManager db)
        {
            _DB = db;
        }

        /// <summary>
        /// 保存商品配送信息
        /// </summary>
        /// <param name="shipiing"></param>
        /// <returns></returns>
        public bool SaveItemShippingSetting(ItemShippingSetting shipiing)
        {
            var command = _DB.GetCommand("SaveItemShippingSetting");
            var result = command.ExecuteNonQuery(new { ItemNumber=shipiing.ItemNumber
            ,ShippingAddress=shipiing.ShippingAddress
            ,Contacts=shipiing.Contacts
            ,Tel=shipiing.Tel
            ,ShippingMethod=shipiing.ShippingMethod
            ,ShippingRate=shipiing.ShippingRate
            });

            return result > 0;
        }
    }
}
