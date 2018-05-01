using System;
using System.Collections.Generic;
using System.Text;
using New3C_Model;
using New3C_Service;
using New3C_DataService;

namespace New3C_Servicelmpl
{
    public class ItemDetailServicelmpl:ItemDetailService
    {
        private readonly ItemDetailDataService _itemDetailDataService;

        public ItemDetailServicelmpl(ItemDetailDataService itemDetailDataService)
        {
            _itemDetailDataService = itemDetailDataService;
        }

        /// <summary>
        /// 查询商品价格分类信息
        /// </summary>
        /// <param name="ItemNumber"></param>
        /// <returns></returns>
        public List<ItemCategoryPrice> GetItemCategoryPrice(string ItemNumber)
        {
            return _itemDetailDataService.GetItemCategoryPrice(ItemNumber);
        }

        /// <summary>
        /// 创建新商品
        /// </summary>
        /// <param name="NewItem"></param>
        /// <returns></returns>
        public int CreateItem(ItemCreation NewItem)
        {
            //创建商品获得ItemNumber
            var itemNumber = _itemDetailDataService.CreateNewItem(NewItem);

            //更新图片表
            NewItem.ItemNumber = itemNumber;

            var result = _itemDetailDataService.AddItemImage(NewItem);

            //更新商品子类表
            var subResult = _itemDetailDataService.AddItemSubcategory(NewItem);

            return itemNumber;
        }
    }
}
