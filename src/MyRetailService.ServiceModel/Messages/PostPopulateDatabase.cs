using ServiceStack;
using System.Runtime.Serialization;

namespace MyRetailService.ServiceModel.Messages
{
    [Route("/Products/",
    Verbs = "POST",
    Notes = "Populates MongoDB with a few products",
    Summary = "Populates MongoDB with a few products")]
    [DataContract]

    public class PostPopulateDatabase
    {
        #region Properties

        [DataMember(Order = 1)]
        public bool GenerateProducts { get; set; }

        #endregion
    }
}
