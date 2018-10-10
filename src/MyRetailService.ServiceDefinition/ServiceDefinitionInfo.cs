using System.Reflection;

namespace MyRetailService.ServiceDefinition
{
    public static class ServiceDefinitionInfo
    {
        public static Assembly Assembly
        {
            get
            {
                return typeof(ServiceDefinitionInfo).Assembly;
            }
        }

        public static readonly string Name = "ServiceDefinitionInfo";
    }
}
