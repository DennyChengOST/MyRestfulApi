using MyRetailService.ServiceModel.Types;
using ServiceStack;
using System;
using System.Runtime.Serialization;

namespace MyRetailService.ServiceModel.Messages
{
    [Route("/Products/{Id}",
    Verbs = "PUT",
    Notes = "Supports updating price for a given product Id",
    Summary = "Put updating product price by product id")]
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
