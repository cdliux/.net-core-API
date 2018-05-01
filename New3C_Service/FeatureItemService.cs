using System;
using System.Collections.Generic;
using System.Text;
using New3C_Model;

namespace New3C_Service
{
    public interface FeatureItemService
    {
        List<Item> GetFeatureList(string Action);
    }
}
