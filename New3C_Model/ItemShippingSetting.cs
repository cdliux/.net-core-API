using System;
using System.Collections.Generic;
using System.Text;

namespace New3C_Model
{
    public class ItemShippingSetting
    {
        public string Contacts { get; set; }
        public bool ShippingMethod { get; set; }
        public string ShippingAddress { get; set; }
        public decimal ShippingRate { get; set; }
        public string Tel { get; set; }
        public int ItemNumber { get; set; }
    }
}
