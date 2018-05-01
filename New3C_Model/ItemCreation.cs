using System;
using System.Collections.Generic;
using System.Text;

namespace New3C_Model
{
    public class ItemCreation:Item
    {
        public List<ItemSubCategoryInfo> subCategoryInfo { get; set; }

    }
    
    public class ItemSubCategoryInfo
    {
        public string CategoryPicID { get; set; }
        public string ItemsCategoryItemName { get; set; }
        public decimal ItemsCategoryPrice { get; set; }
        public string ItemImageUrl { get; set; }
    }
}
