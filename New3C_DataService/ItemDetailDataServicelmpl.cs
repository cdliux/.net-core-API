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
using System.Xml.Linq;

namespace New3C_DataServicelmpl
{
    public class ItemDetailDataServicelmpl:ItemDetailDataService
    {
        public static IDbManager _DB;

        public ItemDetailDataServicelmpl(IDbManager dbManager)
        {
            _DB = dbManager;
        }

        public List<ItemCategoryPrice> GetItemCategoryPrice(string ItemNumber)
        {
            var cmd = _DB.GetCommand("GetItemCategoryPrice");
            List<ItemCategoryPrice> ItemCategoryPriceList = cmd.ExecuteEntityList<ItemCategoryPrice>(new { ItemNum= ItemNumber });
            return ItemCategoryPriceList;
        }

        /// <summary>
        /// 创建新商品
        /// </summary>
        /// <param name="NewItem"></param>
        /// <returns></returns>
        public int CreateNewItem(ItemCreation NewItem)
        {
            var command = _DB.GetCommand("AddNewItem");
            var itemNumber = command.ExecuteScalar<int>(new { StoreId=NewItem.StoreId
                ,ItemName=NewItem.ItemName
                ,SubCategoryId=NewItem.SubCategoryId
                ,Price=NewItem.Price
                ,Inventory=NewItem.Inventory
                ,ItemStatus="Active"
                ,IsPromotionItem=NewItem.IsPromotionItem
                ,CategoryId=NewItem.CategoryId
                ,Indate=DateTime.Now.ToString()
            });
            return itemNumber;
        }

        /// <summary>
        /// 更新Item图片
        /// </summary>
        /// <param name="NewItem"></param>
        /// <returns></returns>
        public bool AddItemImage(ItemCreation NewItem)
        {
            //XML批量插入
            var ItemListXml = new XElement("ItemImageList");
            foreach(var item in NewItem.subCategoryInfo)
            {
                List<XElement> img = new List<XElement>();
                img.Add(new XElement("ItemNumber", NewItem.ItemNumber));
                img.Add(new XElement("ItemImageUrl", item.ItemImageUrl));
                img.Add(new XElement("CategoryPicID", item.CategoryPicID));
                ItemListXml.Add(new XElement("ItemImage", img.ToArray()));
            }
            var command = _DB.GetCommand("AddNewItemImage");
            var result = command.ExecuteNonQuery(new{ RequestXML = ItemListXml.ToString()});

            return result > 0;
        }

        /// <summary>
        /// 更新商品子类价格表
        /// </summary>
        /// <param name="NewItem"></param>
        /// <returns></returns>
        public bool AddItemSubcategory(ItemCreation NewItem)
        {
            //XML批量插入
            var SubItemListXml = new XElement("SubItemList");
            foreach (var item in NewItem.subCategoryInfo)
            {
                List<XElement> img = new List<XElement>();
                img.Add(new XElement("ItemNumber", NewItem.ItemNumber));
                img.Add(new XElement("StoreId", NewItem.StoreId));
                img.Add(new XElement("ItemsCategoryName", item.ItemsCategoryItemName));
                img.Add(new XElement("ItemsCategoryPrice", item.ItemsCategoryPrice));
                img.Add(new XElement("CategoryPicID", item.CategoryPicID));
                SubItemListXml.Add(new XElement("Item", img.ToArray()));
            }
            var command = _DB.GetCommand("AddSubItem");
            var result = command.ExecuteNonQuery(new { RequestXML = SubItemListXml.ToString() });

            return result > 0;
        }



    }
}
