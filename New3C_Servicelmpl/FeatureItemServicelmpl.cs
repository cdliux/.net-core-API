using System;
using System.Collections.Generic;
using System.Text;
using New3C_Model;
using New3C_Service;
using New3C_DataService;

namespace New3C_Servicelmpl
{
    public class FeatureItemServicelmpl:FeatureItemService
    {


        private readonly FeatureItemDataService _featureItemDataService;

        public FeatureItemServicelmpl(FeatureItemDataService  featureItemDataService)
        {
            _featureItemDataService = featureItemDataService;
        }
        public List<Item> GetFeatureList(string Action)
        {
            return  _featureItemDataService.GetFeatureItemList(Action);
        }
    }
}
