using ServiceStack;
using System;
using System.Runtime.Serialization;

namespace MyRetailService.ServiceModel.Messages
{
    [Route("/Products/{Id}",
    Verbs = "GET",
    Notes = "Supports getting product details for a given product Id",
    Summary = "Get product details by product id")]
    [DataContract]
    public class GetProductRequest : IReturn<GetProductResponse>
    {
        #region Properties

        [DataMember(Order = 1)]
        public Int64 Id { get; set; }

        #endregion
    }
}
