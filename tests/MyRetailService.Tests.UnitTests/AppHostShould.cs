using ServiceStack.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyRetailService.Tests.UnitTests
{
    [TestClass]
    public class AppHostShould
    {
        [TestMethod]
        public void Configure_AllScenarios_JsonConfigured()
        {
            //Arrange
            var appHost = new AppHost();
            var funqContainer = new Funq.Container();

            //Act
            appHost.Configure(funqContainer);

            //Assert
            Assert.IsTrue(JsConfig.EmitCamelCaseNames);
            Assert.AreEqual(DateHandler.ISO8601, JsConfig.DateHandler);
        }
    }
}
