using CodeStage.AntiCheat.ObscuredTypes;
using HarmonyLib;
using PulsarPluginLoader;
using System;
using System.Collections.Generic;
using System.Reflection;
using Logger = PulsarPluginLoader.Utilities.Logger;

namespace ContentMod.Components.MissionShipComponent
{
    public class MissionShipComponentPluginManager
    {
        public readonly int VanillaMissionShipComponentMaxType = 0;
        private static MissionShipComponentPluginManager m_instance = null;
        public readonly List<MissionShipComponentPlugin> MissionShipComponentTypes = new List<MissionShipComponentPlugin>();
        public static MissionShipComponentPluginManager Instance
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance = new MissionShipComponentPluginManager();
                }
                return m_instance;
            }
        }

        MissionShipComponentPluginManager()
        {
            VanillaMissionShipComponentMaxType = 13;
            Logger.Info($"MaxTypeint = {VanillaMissionShipComponentMaxType - 1}");
            foreach (PulsarPlugin plugin in PluginManager.Instance.GetAllPlugins())
            {
                Assembly asm = plugin.GetType().Assembly;
                Type MissionShipComponentPlugin = typeof(MissionShipComponentPlugin);
                foreach (Type t in asm.GetTypes())
                {
                    if (MissionShipComponentPlugin.IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                    {
                        Logger.Info("Loading MissionShipComponent from assembly");
                        MissionShipComponentPlugin MissionShipComponentPluginHandler = (MissionShipComponentPlugin)Activator.CreateInstance(t);
                        if (GetMissionShipComponentIDFromName(MissionShipComponentPluginHandler.Name) == -1)
                        {
                            MissionShipComponentTypes.Add(MissionShipComponentPluginHandler);
                            Logger.Info($"Added MissionShipComponent: '{MissionShipComponentPluginHandler.Name}' with ID '{GetMissionShipComponentIDFromName(MissionShipComponentPluginHandler.Name)}'");
                        }
                        else
                        {
                            Logger.Info($"Could not add MissionShipComponent from {plugin.Name} with the duplicate name of '{MissionShipComponentPluginHandler.Name}'");
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Finds MissionShipComponent type equivilent to given name and returns Subtype ID needed to spawn. Returns -1 if couldn't find MissionShipComponent.
        /// </summary>
        /// <param name="MissionShipComponentName"></param>
        /// <returns></returns>
        public int GetMissionShipComponentIDFromName(string MissionShipComponentName)
        {
            for (int i = 0; i < MissionShipComponentTypes.Count; i++)
            {
                if (MissionShipComponentTypes[i].Name == MissionShipComponentName)
                {
                    return i + VanillaMissionShipComponentMaxType;
                }
            }
            return -1;
        }
        public static PLMissionShipComponent CreateMissionShipComponent(int Subtype, int level)
        {
            PLMissionShipComponent InMissionShipComponent;
            if (Subtype >= Instance.VanillaMissionShipComponentMaxType)
            {
                InMissionShipComponent = new PLMissionShipComponent(0, level);
                int subtypeformodded = Subtype - Instance.VanillaMissionShipComponentMaxType;
                if (Global.DebugLogging)
                {
                    Logger.Info($"Subtype for modded is {subtypeformodded}");
                }
                if (subtypeformodded <= Instance.MissionShipComponentTypes.Count && subtypeformodded > -1)
                {
                    if (Global.DebugLogging)
                    {
                        Logger.Info("Creating MissionShipComponent from list info");
                    }
                    MissionShipComponentPlugin MissionShipComponentType = Instance.MissionShipComponentTypes[Subtype - Instance.VanillaMissionShipComponentMaxType];
                    InMissionShipComponent.SubType = Subtype;
                    InMissionShipComponent.Name = MissionShipComponentType.Name;
                    InMissionShipComponent.Desc = MissionShipComponentType.Description;
                    InMissionShipComponent.GetType().GetField("m_IconTexture", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(InMissionShipComponent, MissionShipComponentType.IconTexture);
                    InMissionShipComponent.GetType().GetField("m_MarketPrice", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(InMissionShipComponent, (ObscuredInt)MissionShipComponentType.MarketPrice);
                    InMissionShipComponent.CargoVisualPrefabID = MissionShipComponentType.CargoVisualID;
                    InMissionShipComponent.CanBeDroppedOnShipDeath = MissionShipComponentType.CanBeDroppedOnShipDeath;
                    InMissionShipComponent.Experimental = MissionShipComponentType.Experimental;
                    InMissionShipComponent.Unstable = MissionShipComponentType.Unstable;
                    InMissionShipComponent.Contraband = MissionShipComponentType.Contraband;
                }
            }
            else
            {
                InMissionShipComponent = new PLMissionShipComponent(Subtype, level);
            }
            return InMissionShipComponent;
        }
    }
    //Converts hashes to MissionShipComponents.
    [HarmonyPatch(typeof(PLMissionShipComponent), "CreateMissionComponentFromHash")]
    class MissionShipComponentHashFix
    {
        static bool Prefix(int inSubType, int inLevel, ref PLShipComponent __result)
        {
            __result = MissionShipComponentPluginManager.CreateMissionShipComponent(inSubType, inLevel);
            return false;
        }
    }
    /*[HarmonyPatch(typeof(PLMissionShipComponent), "Tick")]
    class TickPatch
    {
        static void Postfix(PLMissionShipComponent __instance)
        {
            int subtypeformodded = __instance.SubType - MissionShipComponentPluginManager.Instance.VanillaMissionShipComponentMaxType;
            if (subtypeformodded > -1 && subtypeformodded < MissionShipComponentPluginManager.Instance.MissionShipComponentTypes.Count && __instance.ShipStats != null && __instance.ShipStats.MissionShipComponentTempMax != 0f)
            {
                MissionShipComponentPluginManager.Instance.MissionShipComponentTypes[subtypeformodded].MissionShipComponentPowerCode(__instance);
            }
        }
    }*/
}
