namespace DalApi;

using DalApi;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;
using System;
using static DalApi.DalConfig;
using DO;

public static class Factory
{
    public static IDal Get
    {
        get
        {
            string dalType = s_dalName ??
                throw new DalConfigException($"DAL name is not extracted from the configuration");

            string dal = s_dalPackages[dalType] ??
                throw new DalConfigException($"Package for {dalType} is not found in packages list in dal - config.xml!!!!!!!!!!!!!!!!!!!!");
            try
            {
                Assembly.Load(dal ?? throw new DalConfigException($"Package {dal} is null"));
            }
            catch (Exception ex)
            {
                throw new DalConfigException($"Failed to load {dal}.dll package");
            }
            Type type = Type.GetType($"Dal.{dal}, {dal}") ??
                throw new DalConfigException($"Class Dal.{dal} was not found in {dal}.packege.dll");
            return type.GetProperty("Instance", BindingFlags.Public | BindingFlags.Static)?.GetValue(null) as IDal ??
                throw new DalConfigException($"Class {dal} is not a singleton or wrong property name for Instance");
        }
    }
}

/*namespace DalApi;
using static DalApi.DalConfig;
using System.Reflection;
using DO;

public static class Factory
{
    public static IDal Get
    {
        get
        {
            string dalType = s_dalName ?? throw new DalConfigException($"DAL name is not extracted from the configuration");
            string dal = s_dalPackages[dalType] ?? throw new DalConfigException($"Package for {dalType} is not found in packages list in dal-config.xml");

            try { Assembly.Load(dal ?? throw new DalConfigException($"Package {dal} is null")); }
            catch (Exception ex) { throw new DalConfigException($"Failed to load {dal}.dll package", ex); }

            Type type = Type.GetType($"Dal.{dal}, {dal}") ??
                throw new DalConfigException($"Class Dal.{dal} was not found in {dal}.dll");

            // First try to get a public static Instance property (singleton pattern)
            var prop = type.GetProperty("Instance", BindingFlags.Public | BindingFlags.Static);
            if (prop != null)
            {
                return prop.GetValue(null) as IDal ??
                    throw new DalConfigException($"Class {dal} 'Instance' property did not return IDal");
            }

            // Otherwise try to create an instance using a public parameterless ctor
            try
            {
                var inst = Activator.CreateInstance(type) as IDal;
                if (inst != null) return inst;
            }
            catch (Exception ex)
            {
                throw new DalConfigException($"Failed to create an instance of {dal}", ex);
            }

            throw new DalConfigException($"Class {dal} is not a singleton and could not be instantiated as IDal");
        }
    }
}
*/