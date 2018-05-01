using System;
using System.Collections.Generic;
using System.Text;
using New3C_Model;
using New3C_DataService;
using New3C_Service;

namespace New3C_Servicelmpl
{
    public class ItemShippingSettingServicelmpl: IItemShippingSettingServices
    {
        private readonly IItemShippingSettingDataService _itemShippingService;

        public ItemShippingSettingServicelmpl(IItemShippingSettingDataService ItemShippingSettingDataService)
        {
            _itemShippingService = ItemShippingSettingDataService;
        }

        public bool SaveItemShippingSetting(ItemShippingSetting shipping)
        {
            if (shipping.ShippingMethod == true)
                shipping.ShippingRate = 0;
            return _itemShippingService.SaveItemShippingSetting(shipping);
        }
    }
}
