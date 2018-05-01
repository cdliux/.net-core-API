using System;
using System.Collections.Generic;
using System.Text;

namespace New3C_Model
{
    public class Item
    {
        public int ItemNumber { get; set; }
        public string StoreId { get; set; }
        public string ItemName { get; set; }
        public string SubCategoryId { get; set; }
        public decimal Price { get; set; }
        public decimal PromotionPrice { get; set; }
        public int Inventory { get; set; }
        public string ManufactureId { get; set; }
        public string DomainId { get; set; }
        public string CategoryId { get; set; }
        public string ItemStatus { get; set; }
        public bool IsFeatureItem { get; set; }
        public bool IsPromotionItem { get; set; }
        public string ItemImageUrl { get; set; }
    }
}
