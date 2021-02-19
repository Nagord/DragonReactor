using HarmonyLib;
using PulsarPluginLoader;
using System;
using System.Collections.Generic;
using System.Reflection;
using Logger = PulsarPluginLoader.Utilities.Logger;

namespace DragonReactor.HullPlating
{
    class HullPlatingPluginManager
    {
        public readonly int VanillaHullPlatingMaxType = 0;
        private static HullPlatingPluginManager m_instance = null;
        public readonly List<HullPlatingPlugin> HullPlatingTypes = new List<HullPlatingPlugin>();
        public static HullPlatingPluginManager Instance
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance = new HullPlatingPluginManager();
                }
                return m_instance;
            }
        }

        HullPlatingPluginManager()
        {
            VanillaHullPlatingMaxType = Enum.GetValues(typeof(ETrackerMissileType)).Length;
            Logger.Info($"MaxTypeint = {VanillaHullPlatingMaxType - 1}");
            foreach (PulsarPlugin plugin in PluginManager.Instance.GetAllPlugins())
            {
                Assembly asm = plugin.GetType().Assembly;
                Type HullPlatingPlugin = typeof(HullPlatingPlugin);
                foreach (Type t in asm.GetTypes())
                {
                    if (HullPlatingPlugin.IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                    {
                        Logger.Info("Loading HullPlating from assembly");
                        HullPlatingPlugin HullPlatingPluginHandler = (HullPlatingPlugin)Activator.CreateInstance(t);
                        if (GetHullPlatingIDFromName(HullPlatingPluginHandler.Name) == -1)
                        {
                            HullPlatingTypes.Add(HullPlatingPluginHandler);
                            Logger.Info($"Added HullPlating: '{HullPlatingPluginHandler.Name}' with ID '{GetHullPlatingIDFromName(HullPlatingPluginHandler.Name)}'");
                        }
                        else
                        {
                            Logger.Info($"Could not add HullPlating from {plugin.Name} with the duplicate name of '{HullPlatingPluginHandler.Name}'");
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Finds HullPlating type equivilent to given name and returns Subtype ID needed to spawn. Returns -1 if couldn't find HullPlating.
        /// </summary>
        /// <param name="HullPlatingName"></param>
        /// <returns></returns>
        public int GetHullPlatingIDFromName(string HullPlatingName)
        {
            for (int i = 0; i < HullPlatingTypes.Count; i++)
            {
                if (HullPlatingTypes[i].Name == HullPlatingName)
                {
                    return i + VanillaHullPlatingMaxType;
                }
            }
            return -1;
        }
        /*public static PLShipComponent CreateHullPlating(int Subtype, int level)
        {
            PLShipComponent InHullPlating;
            if (Subtype >= Instance.VanillaHullPlatingMaxType)
            {
                InHullPlating = new PLHullPlating(level);
                int subtypeformodded = Subtype - Instance.VanillaHullPlatingMaxType;
                Logger.Info($"Subtype for modded is {subtypeformodded}");
                if (subtypeformodded <= Instance.HullPlatingTypes.Count && subtypeformodded > -1)
                {
                    Logger.Info("Creating HullPlating from list info");
                }
            }
            else
            {
                InHullPlating = new PLHullPlating(level);
            }
            return InHullPlating;
        }*/
    }
    //Converts hashes to HullPlatings.
    [HarmonyPatch(typeof(PLHullPlating), "CreateHullPlatingFromHash")]
    class HullPlatingHashFix
    {
        static bool Prefix(int inSubType, int inLevel, ref PLShipComponent __result)
        {
            int subtypeformodded = inSubType - HullPlatingPluginManager.Instance.VanillaHullPlatingMaxType;
            if (subtypeformodded <= HullPlatingPluginManager.Instance.HullPlatingTypes.Count && subtypeformodded > -1)
            {
                Logger.Info("Creating HullPlating from list info");
                __result = HullPlatingPluginManager.Instance.HullPlatingTypes[subtypeformodded].PLHullPlating;
                __result.Level = inLevel;
                return false;
            }
            return true;
        }
    }
}
