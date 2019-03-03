using System;
using System.IO;
using System.Reflection;
using static System.IO.Path;

namespace ConEmuLauncher
{
    static class Program
    {
        static void Main(string[] args)
        {
            var selfDir = GetDirectoryName(Assembly.GetEntryAssembly().Location);

            string conemuPath = null;
            if (Environment.Is64BitOperatingSystem)
            {
                conemuPath = Combine(selfDir, "ConEmu64.exe");
                if (!File.Exists(conemuPath))
                    conemuPath = null;
            }

            if (conemuPath is null)
            {
                conemuPath = Combine(selfDir, "ConEmu.exe");
                if (!File.Exists(conemuPath))
                    conemuPath = null;
            }

            if (conemuPath is null) return;

            System.Diagnostics.Process.Start(conemuPath, "-Single " + string.Join(" ", args));
        }
    }
}
