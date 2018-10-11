using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MyRetailService.Tests.UnitTests.Helpers;

namespace MyRetailService.Tests.UnitTests
{
    [TestClass]
    public class ConfigShould
    {
        private const string MyRetailServiceAppConfigPath = "..\\..\\..\\..\\src\\MyRetailService\\Web.config";
        private const string MyRetailServiceTokenPath = "..\\..\\..\\..\\src\\MyRetailService\\Web.config.token";
        private const string AcceptanceTestAppConfigPath = "..\\..\\..\\MyRetailService.Tests.AcceptanceTests\\App.config";
        private const string AcceptanceTestTokenPath = "..\\..\\..\\MyRetailService.Tests.AcceptanceTests\\App.config.token";
        
        [TestMethod]
        public void AppSettingsInPluginConfig_Keys_MatchTokenFile()
        {
            List<string> appSettingsKeys;
            using (AppConfig.Change(MyRetailServiceAppConfigPath))
            {
                // tempFileName is used for the app config during this context
                appSettingsKeys = ConfigurationManager.AppSettings.AllKeys.Select(key => key).ToList();
            }

            List<string> appSettingsTokenKeys;
            List<string> connectionStringTokenNames = new List<string>();
            using (AppConfig.Change(MyRetailServiceTokenPath))
            {
                // tempFileName is used for the app config during this context
                appSettingsTokenKeys = ConfigurationManager.AppSettings.AllKeys.Select(key => key).ToList();
            }

            foreach (var key in appSettingsKeys)
            {
                Assert.IsTrue(appSettingsTokenKeys.Any(k => k == key), $"Key:{key} not found in AppSettings section of token file.");
            }

            foreach (var key in appSettingsTokenKeys)
            {
                Assert.IsTrue(appSettingsKeys.Any(k => k == key), $"Key:{key} not found in AppSettings section of config file.");
            }
        }

        [TestMethod]
        public void AppSettingsInAATConfig_Keys_MatchTokenFile()
        {
            List<string> keys;
            using (AppConfig.Change(AcceptanceTestAppConfigPath))
            {
                // tempFileName is used for the app config during this context
                keys = ConfigurationManager.AppSettings.AllKeys.Select(key => key).ToList();
            }

            List<string> tokenKeys;
            using (AppConfig.Change(AcceptanceTestTokenPath))
            {
                // tempFileName is used for the app config during this context
                tokenKeys = ConfigurationManager.AppSettings.AllKeys.Select(key => key).ToList();
            }

            foreach (var key in keys)
            {
                Assert.IsTrue(tokenKeys.Any(k => k == key), $"Key:{key} not found in AppSettings section of AAT token file.");
            }

            foreach (var key in tokenKeys)
            {
                Assert.IsTrue(keys.Any(k => k == key), $"Key:{key} not found in AppSettings section of AAT config file.");
            }
        }

        [TestMethod]
        public void AssemblyRedirectsInWebConfig_MatchWebConfigToken()
        {
            var webConfigXmlDoc = XDocument.Load(MyRetailServiceAppConfigPath);
            var webConfigTokenXmlDoc = XDocument.Load(MyRetailServiceTokenPath);

            var webConfigXmlAssemblyBindingElement = webConfigXmlDoc.Descendants().FirstOrDefault(element => element.Name.LocalName == "assemblyBinding");
            var webConfigTokenXmlAssemblyBindingElement = webConfigTokenXmlDoc.Descendants().FirstOrDefault(element => element.Name.LocalName == "assemblyBinding");

            Assert.AreEqual(webConfigXmlAssemblyBindingElement?.ToString(), webConfigTokenXmlAssemblyBindingElement?.ToString());
        }

        [TestMethod]
        public void ConnectionStringsInPluginConfig_Names_MatchTokenFile()
        {
            List<string> connectionStringNames = new List<string>();
            using (AppConfig.Change(MyRetailServiceAppConfigPath))
            {
                // tempFileName is used for the app config during this context
                foreach (ConnectionStringSettings connectionStringSetting in ConfigurationManager.ConnectionStrings)
                {
                    if ((connectionStringSetting.ElementInformation.Source != null)
                        && (connectionStringSetting.ElementInformation.Source.EndsWith(MyRetailServiceAppConfigPath)))
                    {
                        connectionStringNames.Add(connectionStringSetting.Name);
                    }
                }
            }

            List<string> connectionStringTokenNames = new List<string>();
            using (AppConfig.Change(MyRetailServiceTokenPath))
            {
                // tempFileName is used for the app config during this context
                foreach (ConnectionStringSettings connectionStringSetting in ConfigurationManager.ConnectionStrings)
                {
                    if ((connectionStringSetting.ElementInformation.Source != null)
                        && (connectionStringSetting.ElementInformation.Source.EndsWith(MyRetailServiceTokenPath)))
                    {
                        connectionStringTokenNames.Add(connectionStringSetting.Name);
                    }
                }
            }

            foreach (var name in connectionStringNames)
            {
                Assert.IsTrue(connectionStringTokenNames.Any(n => n == name), $"Name:{name} not found in ConnectionStrings section of token config file.");
            }

            foreach (var name in connectionStringTokenNames)
            {
                Assert.IsTrue(connectionStringNames.Any(n => n == name), $"Name:{name} not found in ConnectionStrings section of config file.");
            }
        }

        [TestMethod]
        public void ConnectionStringsInAATConfig_Names_MatchTokenFile()
        {
            List<string> connectionStringNames = new List<string>();
            using (AppConfig.Change(AcceptanceTestAppConfigPath))
            {
                // tempFileName is used for the app config during this context
                foreach (ConnectionStringSettings connectionStringSetting in ConfigurationManager.ConnectionStrings)
                {
                    if ((connectionStringSetting.ElementInformation.Source != null)
                        && (connectionStringSetting.ElementInformation.Source.EndsWith(AcceptanceTestAppConfigPath)))
                    {
                        connectionStringNames.Add(connectionStringSetting.Name);
                    }
                }
            }

            List<string> connectionStringTokenNames = new List<string>();
            using (AppConfig.Change(AcceptanceTestTokenPath))
            {
                // tempFileName is used for the app config during this context
                foreach (ConnectionStringSettings connectionStringSetting in ConfigurationManager.ConnectionStrings)
                {
                    if ((connectionStringSetting.ElementInformation.Source != null)
                        && (connectionStringSetting.ElementInformation.Source.EndsWith(AcceptanceTestTokenPath)))
                    {
                        connectionStringTokenNames.Add(connectionStringSetting.Name);
                    }
                }
            }

            foreach (var name in connectionStringNames)
            {
                Assert.IsTrue(connectionStringTokenNames.Any(n => n == name), $"Name:{name} not found in ConnectionStrings section of token config file.");
            }

            foreach (var name in connectionStringTokenNames)
            {
                Assert.IsTrue(connectionStringNames.Any(n => n == name), $"Name:{name} not found in ConnectionStrings section of config file.");
            }
        }
    }
}
