using MyRetailService.ServiceModel.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRetailService.DataModels
{
    public class ProductDetailsModel
    {
        public Int64 Id { get; set; }

        public string Name { get; set; }

        public ProductPrice CurrentPrice { get; set; }
        //generic class with enums for currency types
    }
}
