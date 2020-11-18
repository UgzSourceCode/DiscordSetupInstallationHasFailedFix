using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordSetupInstallationHasFailedFix
{
    class Program
    {
        private static string DiscordLocalFolerName = @"discord";
        private static string DiscordProcessName = "Discord";

        private static Process[] GetDiscordProcesses()
        {
            return Process.GetProcessesByName(DiscordProcessName);
        }

        private static void KillProcesses(Process[] processes)
        {
            foreach (var process in processes)
            {
                process.Kill();
            }
        }

        private static void Empty(System.IO.DirectoryInfo directory)
        {
            foreach (System.IO.FileInfo file in directory.GetFiles()) file.Delete();
            foreach (System.IO.DirectoryInfo subDirectory in directory.GetDirectories()) subDirectory.Delete(true);
            
        }

        private static string GetUrlAppDataFolder()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        }

        private static void RemoveDiscordLocalFolder()
        {
            var discordLocalFoler = GetUrlAppDataFolder() + @"/" + DiscordLocalFolerName;
            System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo(discordLocalFoler);
            if (directory.Exists)
                directory.Delete(true);
        }

        private static void Main(string[] args)
        {
            KillProcesses(GetDiscordProcesses());
            RemoveDiscordLocalFolder();
        }
    }
}
