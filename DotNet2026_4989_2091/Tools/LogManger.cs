using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Tools;

public static class LogManager
{
    private static readonly string path = "Log";//const

    public static string getFolderLogPath()
    {
        int year = DateTime.Now.Year;
        int month = DateTime.Now.Month;
        return $"{path}\\{month}.{year}";
    }

    public static string getFileLogPath()
    {
        int year = DateTime.Now.Year;
        int month = DateTime.Now.Month;
        int day = DateTime.Now.Day;
        return $"{path}\\{day}.{month}.{year}";
    }
    public static void writeToLog(string projectName, string funcName, string message)
    {
        string logPathFolder = getFolderLogPath();
        string logPathFile = getFileLogPath();
        if (!Directory.Exists(logPathFolder))
            Directory.CreateDirectory(logPathFolder);
        if (!File.Exists(logPathFile))
            File.Create(logPathFile);
        string logPath = $"{path}\\{logPathFolder}\\{logPathFile}";
        FileStream file = new FileStream(@logPath, FileMode.Append, FileAccess.Write);
        StreamWriter writer = new StreamWriter(file);
        writer.WriteLine($"{DateTime.Now}\t{projectName}.{funcName}\t{message}");

    }
    public static void clearLogs()
    {
        DateTime dateBefore = DateTime.Now.AddMonths(-2);
        String[] dir = Directory.GetDirectories(path);
        for (int i = 0; i < dir.Length; i++)
        {
            String dirName = dir[i];
            string[] parts = dirName.Split('.');

            int month = int.Parse(parts[0]);
            int year = int.Parse(parts[1]);
            if(year<dateBefore.Year||(year==dateBefore.Year&&month<dateBefore.Month))
                Directory.Delete($"{path}\\{dirName}", true);
        }
    }
}

