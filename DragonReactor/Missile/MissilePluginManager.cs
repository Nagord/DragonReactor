using CodeStage.AntiCheat.ObscuredTypes;
using HarmonyLib;
using PulsarPluginLoader;
using System;
using System.Collections.Generic;
using System.Reflection;
using Logger = PulsarPluginLoader.Utilities.Logger;

namespace DragonReactor.Missile
{
    public class MissilePluginManager
    {
        public readonly int VanillaMissileMaxType = 0;
        private static MissilePluginManager m_instance = null;
        public readonly List<MissilePlugin> MissileTypes = new List<MissilePlugin>();
        public static MissilePluginManager Instance
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance = new MissilePluginManager();
                }
                return m_instance;
            }
        }

        MissilePluginManager()
        {
            VanillaMissileMaxType = Enum.GetValues(typeof(ETrackerMissileType)).Length;
            Logger.Info($"MaxTypeint = {VanillaMissileMaxType - 1}");
            foreach (PulsarPlugin plugin in PluginManager.Instance.GetAllPlugins())
            {
                Assembly asm = plugin.GetType().Assembly;
                Type MissilePlugin = typeof(MissilePlugin);
                foreach (Type t in asm.GetTypes())
                {
                    if (MissilePlugin.IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                    {
                        Logger.Info("Loading Missile from assembly");
                        MissilePlugin MissilePluginHandler = (MissilePlugin)Activator.CreateInstance(t);
                        if (GetMissileIDFromName(MissilePluginHandler.Name) == -1)
                        {
                            MissileTypes.Add(MissilePluginHandler);
                            Logger.Info($"Added Missile: '{MissilePluginHandler.Name}' with ID '{GetMissileIDFromName(MissilePluginHandler.Name)}'");
                        }
                        else
                        {
                            Logger.Info($"Could not add Missile from {plugin.Name} with the duplicate name of '{MissilePluginHandler.Name}'");
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Finds Missile type equivilent to given name and returns Subtype ID needed to spawn. Returns -1 if couldn't find Missile.
        /// </summary>
        /// <param name="MissileName"></param>
        /// <returns></returns>
        public int GetMissileIDFromName(string MissileName)
        {
            for (int i = 0; i < MissileTypes.Count; i++)
            {
                if (MissileTypes[i].Name == MissileName)
                {
                    return i + VanillaMissileMaxType;
                }
            }
            return -1;
        }
        public static PLTrackerMissile CreateMissile(int Subtype, int level)
        {
            PLTrackerMissile InMissile;
            if (Subtype >= Instance.VanillaMissileMaxType)
            {
                InMissile = new PLTrackerMissile(ETrackerMissileType.MAX, level);
                int subtypeformodded = Subtype - Instance.VanillaMissileMaxType;
                Logger.Info($"Subtype for modded is {subtypeformodded}");
                if (subtypeformodded <= Instance.MissileTypes.Count && subtypeformodded > -1)
                {
                    Logger.Info("Creating Missile from list info");
                    MissilePlugin MissileType = Instance.MissileTypes[Subtype - Instance.VanillaMissileMaxType];
                    InMissile.SubType = Subtype;
                    InMissile.Name = MissileType.Name;
                    InMissile.Desc = MissileType.Description;
                    InMissile.GetType().GetField("m_IconTexture", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(InMissile, MissileType.IconTexture);
                    InMissile.Damage = MissileType.Damage;
                    InMissile.Speed = MissileType.Speed;
                    InMissile.DamageType = MissileType.DamageType;
                    InMissile.MissileRefillPrice = MissileType.MissileRefillPrice;
                    InMissile.AmmoCapacity = MissileType.AmmoCapacity;
                    InMissile.PrefabID = MissileType.PrefabID;
                    InMissile.GetType().GetField("m_MarketPrice", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(InMissile, (ObscuredInt)MissileType.MarketPrice);
                    InMissile.CargoVisualPrefabID = MissileType.CargoVisualID;
                    InMissile.CanBeDroppedOnShipDeath = MissileType.CanBeDroppedOnShipDeath;
                    InMissile.Experimental = MissileType.Experimental;
                    InMissile.Unstable = MissileType.Unstable;
                    InMissile.Contraband = MissileType.Contraband;
                }
            }
            else
            {
                InMissile = new PLTrackerMissile((ETrackerMissileType)Subtype, level);
            }
            return InMissile;
        }
    }
    //Converts hashes to Missiles.
    [HarmonyPatch(typeof(PLTrackerMissile), "CreateTrackerMissileFromHash")]
    class MissileHashFix
    {
        static bool Prefix(int inSubType, int inLevel, ref PLShipComponent __result)
        {
            __result = MissilePluginManager.CreateMissile(inSubType, inLevel);
            return false;
        }
    }
}
