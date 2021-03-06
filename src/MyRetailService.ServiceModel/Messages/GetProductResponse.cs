using ServiceStack;
using System;
using System.Runtime.Serialization;

using MyRetailService.ServiceModel.Types;

namespace MyRetailService.ServiceModel.Messages
{
    [DataContract]
    public class GetProductResponse : IHasResponseStatus
    {
        #region IHasResponseStatus Implementation

        [DataMember(Order = 1)]
        public ResponseStatus ResponseStatus { get; set; }

        #endregion

        [DataMember(Order = 2)]
        public Int64 Id { get; set; }

        [DataMember(Order = 3)]
        public string Name { get; set; }

        [DataMember(Order = 4)]
        public ProductPrice CurrentPrice { get; set; }
    }
}
