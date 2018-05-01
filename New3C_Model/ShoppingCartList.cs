using System;
using System.Collections.Generic;
using System.Text;

namespace New3C_Model
{
    public class ShoppingCartList
    {
        public int ID { get; set; }
        public int ItemNumber { get; set; }
        public string ItemName { get; set; }
        public string ItemImageUrl { get; set; }
        public int Amount { get; set; }
        public string StoreID { get; set; }
        public string CategoryPicID { get; set; }
        public decimal Price { get; set; }
    }
}
