using System;

using MyRetailService.Interfaces.Repositories;

namespace MyRetailService.Repositories
{
    public class RedskyRepository : IRedSkyRepository
    {
        #region Fields


        #endregion

        #region Constructors

        public RedskyRepository()
        {
        }

        #endregion

        #region IRedSkyRepository Implementation

        //thinking is this best practice to just pass back the ID?
        //i'm anticipating this HTTp call would get me only the name and nothing else
        //but reviewing the JSOn i'm not sure how to interpret it.
        //Potentially add mapping config?

        //Also thoughts on the usin the incomin request as place holder objs or should
        //I construct place holder dtos?

        public string GetProductName(Int64 id)
        {
            return "The Big Lebowski (Blu-ray)(WideScreen)";
        }

        #endregion
    }
}
