using CodeStage.AntiCheat.ObscuredTypes;
using HarmonyLib;
using PulsarPluginLoader;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace DragonReactor
{
    class ReactorPluginManager
    {
        private static int VanillaReactorMaxType = 14;
        private static ReactorPluginManager m_instance = null;
        private static List<ReactorPlugin> ReactorTypes = new List<ReactorPlugin>();
        [HarmonyPatch(typeof(PLServer), "Awake")]
        static class DRInstantiate
        {
            static void Postfix(PLServer __instance)
            {
                __instance.gameObject.AddComponent(typeof(ReactorPluginManager));
            }
        }
        public static ReactorPluginManager Instance
        {
            get
            {
                if(m_instance == null)
                {
                    m_instance = new ReactorPluginManager();
                }
                return m_instance;
            }
        }
        
        ReactorPluginManager()
        {
            VanillaReactorMaxType = Enum.GetValues(typeof(EReactorType)).Length;
            foreach (PulsarPlugin plugin in PluginManager.Instance.GetAllPlugins())
            {
                Assembly asm = plugin.GetType().Assembly;
                Type ReactorPlugin = typeof(ReactorPlugin);
                foreach(Type t in asm.GetTypes())
                {
                    if(ReactorPlugin.IsAssignableFrom(t) && !t.IsInterface)
                    {
                        ReactorPlugin ReactorPluginHandler = (ReactorPlugin)Activator.CreateInstance(t);
                        ReactorTypes.Add(ReactorPluginHandler);
                    }
                }
            }
        }
        public static PLReactor CreateReactor(int Subtype, int level, PLReactor InReactor = null)
        {

            if (InReactor == null)
            {
                if ((EReactorType)Subtype > EReactorType.E_SYLVASSI_REACTOR)
                {
                    InReactor = new PLReactor(EReactorType.E_REAC_ID_MAX, level);
                }
                else
                {
                    InReactor = new PLReactor((EReactorType)Subtype, level);
                }
            }
            if (InReactor.SubType == 7)
            {
                InReactor.SubType = Subtype;
                ReactorPlugin PluginReactor = ReactorTypes[Subtype - VanillaReactorMaxType];
                InReactor.Name = PluginReactor.Name;
                InReactor.Desc = PluginReactor.Description;
                InReactor.EnergyOutputMax = PluginReactor.EnergyOutputMax;
                InReactor.EnergySignatureAmt = PluginReactor.EnergySignatureAmount;
                InReactor.TempMax = PluginReactor.MaxTemp;
                InReactor.EmergencyCooldownTime = PluginReactor.EmergencyCooldownTime;
                InReactor.GetType().GetField("m_MarketPrice", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(InReactor, (ObscuredInt)PluginReactor.MarketPrice);
                InReactor.CargoVisualPrefabID = PluginReactor.CargoVisualID;
                InReactor.CanBeDroppedOnShipDeath = PluginReactor.CanBeDroppedOnShipDeath;
                InReactor.Experimental = PluginReactor.Experimental;
                InReactor.Contraband = PluginReactor.Contraband;
                InReactor.GetType().GetField("OriginalEnergyOutputMax", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(InReactor, InReactor.EnergyOutputMax);
            }
            return InReactor;
        }
    }
}
