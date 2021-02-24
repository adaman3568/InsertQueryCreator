using System;
using System.IO;
using DocumentFormat.OpenXml.Drawing;
using Path = System.IO.Path;

namespace SqlQueryBuilderCommon.Static
{
    public class Pathes
    {
        private static string EnvPath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Env");

        public static string GetEnvPath(string fileName)
        {
            if (!Directory.Exists(EnvPath))
            {
                Directory.CreateDirectory(EnvPath);
            }

            return Path.Combine(EnvPath,fileName);
        }

        public static bool ExistsFile(string fileName)
        {
            return Directory.Exists(EnvPath) && File.Exists(Path.Combine(EnvPath, fileName));
        }
    }
}