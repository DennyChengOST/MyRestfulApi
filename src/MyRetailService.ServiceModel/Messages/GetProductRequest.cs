using ServiceStack;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace MyRetailService.ServiceModel.Messages
{
    [Route("/Products/{Id}",
    Verbs = "GET",
    Notes = "Supports getting product details for a given product Id",
    Summary = "Get product details by product id")]
    [DataContract]
    public class GetProductRequest : IReturn<GetProductResponse>
        //getproductrequest**
    {
        #region Properties

        [DataMember(Order = 1)]
        public Int64 Id { get; set; }
        //

        #endregion
    }
}
