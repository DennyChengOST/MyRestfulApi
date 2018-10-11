using ServiceStack;
using System;
using System.Runtime.Serialization;

using MyRetailService.ServiceModel.Types;

namespace MyRetailService.ServiceModel.Messages
{
    [Route("/Products/{Id}",
    Verbs = "PUT",
    Notes = "Supports updating a product for a given product Id",
    Summary = "Put updating product by product id")]
    [DataContract]
    public class PutUpdateProductPrice : IReturn<PutUpdateProductPriceResponse>
    {
        #region Properties

        [DataMember(Order = 1)]
        public Int64 Id { get; set; }

        [DataMember(Order = 2)]
        public string Name { get; set; }

        [DataMember(Order = 3)]
        public ProductPrice CurrentPrice { get; set; }

        #endregion
    }
}
