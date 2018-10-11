using System;

using MyRetailService.ServiceModel.Types;

namespace MyRetailService.DataModels
{
    public class ProductDetailsModel
    {
        public Int64 Id { get; set; }

        public string Name { get; set; }

        public ProductPrice CurrentPrice { get; set; }
    }
}
