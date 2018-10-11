using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyRetailService.ServiceModel.Types
{
    //public enum CurrencyTypes
    //{
    //    USD,
    //    CAD
    //} generic classses/types
    public class ProductPrice
    {
        [DataMember(Order = 1)]
        public decimal Value { get; set; }

        [DataMember(Order = 2)]
        public string CurrencyCode { get; set; }

    }
}
