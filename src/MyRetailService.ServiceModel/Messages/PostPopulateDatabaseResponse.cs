using ServiceStack;
using System.Runtime.Serialization;


namespace MyRetailService.ServiceModel.Messages
{
    [DataContract]
    public class PostPopulateDatabaseResponse : IHasResponseStatus
    {
        #region IHasResponseStatus Implementation

        [DataMember(Order = 1)]
        public ResponseStatus ResponseStatus { get; set; }

        #endregion
    }
}
