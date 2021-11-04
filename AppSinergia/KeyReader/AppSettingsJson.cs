using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AppSinergia.KeyReader
{
    public static class AppSettingsJson
    {
        public static IConfigurationRoot GetAppSettings()
        {
            string applicationExeDirectory = ApplicationExeDirectory();
            var builder = new ConfigurationBuilder()
            .SetBasePath(applicationExeDirectory)
            .AddJsonFile("appsettings.json");
            return builder.Build();
        }

        private static string ApplicationExeDirectory()
        {
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var appRoot = Path.GetDirectoryName(location);
            return appRoot;
        }

    }
}
