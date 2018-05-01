using System;
using System.Collections.Generic;
using System.Text;

namespace New3C_Model
{
    public class ItemCategory
    {
        public List<Domain> DomainList { get; set; }
        public List<Category> CategoryList { get; set; }
        public List<SubCategory> SubCategoryList { get; set; }
    }


    public class Domain
    {
        public int DomainId { get; set; }
        public string DomainName { get; set; }
    }

    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int DomainId { get; set; }
    }

    public class SubCategory
    {
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public int CategoryId { get; set; }
    }
}
