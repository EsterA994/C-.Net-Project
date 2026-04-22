using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Tools;

public static class LogManager
{
    private static readonly string path = "Log";

    public static string GetFolderLogPath()
    {
        int year = DateTime.Now.Year;
        int month = DateTime.Now.Month;
        string logPathFolder = $@"{path}\{year}.{month}";
        if (!Directory.Exists(logPathFolder))
            Directory.CreateDirectory(logPathFolder);
        return logPathFolder;
    }

    public static string GetFileLogPath(string logPathFolder)
    {
        int day = DateTime.Now.Day;
        string logPathFile = $@"{logPathFolder}\{day}.log";
        return logPathFile;
    }

    public static void WriteToLog(string projectName, string funcName, string message)
    {
        string logPathFolder = GetFolderLogPath();
        string logPathFile = GetFileLogPath(logPathFolder);

        using (StreamWriter writer = File.AppendText(logPathFile))
        {
            writer.WriteLine($"{DateTime.Now}\t{projectName}.{funcName}\t{message}");
        }
    }
    public static void ClearLogs()
    {
        DateTime dateBefore = DateTime.Now.AddMonths(-2);
        String[] dir = Directory.GetDirectories(path);
        for (int i = 0; i < dir.Length; i++)
        {
            String dirName = dir[i];
            string[] parts = dirName.Split('.');

            int month = int.Parse(parts[0]);
            int year = int.Parse(parts[1]);
            if (year < dateBefore.Year || (year == dateBefore.Year && month < dateBefore.Month))
                Directory.Delete($"{path}\\{dirName}", true);
        }
    }
}