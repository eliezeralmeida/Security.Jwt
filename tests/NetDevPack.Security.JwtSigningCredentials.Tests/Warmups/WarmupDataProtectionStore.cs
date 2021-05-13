using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace NetDevPack.Security.JwtSigningCredentials.Tests.Warmups
{
    /// <summary>
    /// 
    /// </summary>
    public class WarmupDataProtectionStore : IWarmupTest
    {
        public WarmupDataProtectionStore()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging();
            serviceCollection.AddMemoryCache();
            serviceCollection.AddDataProtection().PersistKeysToFileSystem(new DirectoryInfo(Directory.GetCurrentDirectory()));
            serviceCollection.AddJwksManager().PersistKeysToDataProtection();

            Services = serviceCollection.BuildServiceProvider();
        }
        public ServiceProvider Services { get; set; }

    }
}