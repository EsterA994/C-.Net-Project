using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

//namespace DalApi;

//internal static class DalConfig
//{
//    internal static string? s_dalName;
//    internal static Dictionary<string, string> s_dalPackages = new();

//    static DalConfig()
//    {
//        // Try paths relative to the running assembly and current directory
//        string[] candidates = new[]
//        {
//            Path.Combine(AppContext.BaseDirectory, "xml", "dal-config.xml"),
//            Path.Combine(Directory.GetCurrentDirectory(), "xml", "dal-config.xml"),
//            Path.Combine(AppContext.BaseDirectory, "dal-config.xml"),
//            Path.Combine(Directory.GetCurrentDirectory(), "dal-config.xml")
//        };

//        string? configPath = candidates.FirstOrDefault(File.Exists);
//        if (configPath == null)
//            throw new DalConfigException("dal-config.xml not found in expected locations.");

//        try
//        {
//            var doc = XDocument.Load(configPath);
//            s_dalName = doc.Root?.Element("dal")?.Value?.Trim();

//            var packages = doc.Root?.Element("dal-packages");
//            if (packages != null)
//            {
//                foreach (var elem in packages.Elements())
//                {
//                    var key = elem.Name.LocalName.Trim();
//                    var val = elem.Value.Trim();
//                    if (!s_dalPackages.ContainsKey(key))
//                        s_dalPackages.Add(key, val);
//                }
//            }

//            if (string.IsNullOrEmpty(s_dalName))
//                throw new DalConfigException("Element <dal> is missing or empty in dal-config.xml");
//        }
//        catch (DalConfigException)
//        {
//            throw;
//        }
//        catch (Exception ex)
//        {
//            throw new DalConfigException("Failed to parse dal-config.xml", ex);
//        }
//    }

//    public class DalConfigException : Exception
//    {
//        public DalConfigException() { }
//        public DalConfigException(string message) : base(message) { }
//        public DalConfigException(string message, Exception inner) : base(message, inner) { }
//    }
//}
using System.Xml.Linq;

namespace DalApi;

internal static class DalConfig
{
    internal static string s_dalName;
    internal static Dictionary<string, string> s_dalPackages;

    static DalConfig()
    {
        XElement dalConfig = XElement.Load(@"..\xml\dal-config.xml") ??
  throw new DalConfigException("dal-config.xml file is not found");

        s_dalName =
           dalConfig.Element("dal")?.Value ?? throw new DalConfigException("<dal> element is missing");

        var packages = dalConfig.Element("dal-packages")?.Elements() ??
  throw new DalConfigException("<dal-packages> element is missing");
        s_dalPackages = packages.ToDictionary(p => "" + p.Name, p => p.Value);
    }
}

//[Serializable]
//public class DalConfigException : Exception
//{
//    public DalConfigException(string msg) : base(msg) { }
//    public DalConfigException(string msg, Exception ex) : base(msg, ex) { }
//}