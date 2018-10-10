using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyRetailService.Repositories.TestFoodStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRetailService.Tests.UnitTests.FoodTest
{
    /// <summary>
    /// Summary description for FoodAccessShould
    /// </summary>
    [TestClass]
    public class FoodAccessShould
    {
        private FoodAccess _foodAccess;

        [TestInitialize]
        public void Initialize()
        {
            _foodAccess = new FoodAccess();
        }

        [TestMethod]
        public void FoodGetShould()
        {
            //Arrange
            //_foodAccess.Testfunction();
            //_foodAccess.StoreFood("meow");
            //var food = _foodAccess.SearchFood("Grape");
            //_foodAccess.Updatefood("grape","grapesz");
            //var mewo = "meow";
            //_foodAccess.DeleteFood("meow");
            _foodAccess.StorePrices();
            //var test = _foodAccess.SearchProduct("13860428");


            //Act

            //Assert

        }

    }
}
