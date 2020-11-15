using System.Reflection;
using UnityEngine;
using CodeStage.AntiCheat.ObscuredTypes;

namespace DragonReactor
{
    class ReactorConstructor
	{
		public static PLReactor CreateReactor(int Subtype, int level, PLReactor InReactor = null)
		{
			
			if (InReactor == null)
            {
				InReactor = new PLReactor(EReactorType.E_REAC_ID_MAX, level);
            }
				InReactor.GetType().GetField("m_IconTexture", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(InReactor, (Texture2D)Resources.Load("Icons/28_Reactor"));
				InReactor.Level = level;
				InReactor.SubType = Subtype;
				InReactor.HeatOutput = 1f;
			switch (Subtype)
			{
				default:
					InReactor.Name = "Null Point Reactor";
					InReactor.Desc = "Produces reliable energy output. The design of this reactor was inspired by Old Wars technology, and it is used on many active ships today.";
					InReactor.EnergyOutputMax = 15000f;
					InReactor.EnergySignatureAmt = 18f;
					InReactor.TempMax = 1800f;
					InReactor.EmergencyCooldownTime = 20f;
                    InReactor.GetType().GetField("m_MarketPrice", BindingFlags.Instance | BindingFlags.NonPublic ).SetValue(InReactor, (ObscuredInt)2100);
					InReactor.CargoVisualPrefabID = 11;
					break;
				case (int)EReactorType.E_REAC_WD_NULL_POINT_REACTOR_B:
					InReactor.Name = "Reinforced Null Point Reactor";
					InReactor.Desc = "State-of-the-art energy generation with impressive output. Uses advanced cooling systems coupled with reinforced alloys that can withstand high temperatures. This reactor is not only powerful, but safe.";
					InReactor.EnergyOutputMax = 18000f;
					InReactor.EnergySignatureAmt = 16f;
					InReactor.TempMax = 2400f;
					InReactor.EmergencyCooldownTime = 10f;
					InReactor.GetType().GetField("m_MarketPrice", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(InReactor, (ObscuredInt)3300);
					InReactor.CargoVisualPrefabID = 12;
					break;
				case (int)EReactorType.E_REAC_CU_FUSION_REACTOR:
					InReactor.Name = "Colonial Fusion Reactor";
					InReactor.Desc = "Reliable, safe, and efficient, this reactor was designed for the Colonial Union Fleet but has become one of the most commonly used reactors even on civilian and transport ships. It is tried and true technology.";
					InReactor.EnergyOutputMax = 14500f;
					InReactor.EnergySignatureAmt = 4f;
					InReactor.TempMax = 2200f;
					InReactor.EmergencyCooldownTime = 5f;
					InReactor.GetType().GetField("m_MarketPrice", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(InReactor, (ObscuredInt)2000);
					InReactor.CargoVisualPrefabID = 13;
					break;
				case (int)EReactorType.E_REAC_CU_FUSION_REACTOR_MK2:
					InReactor.Name = "Military-Grade Fusion Reactor";
					InReactor.Desc = "Newer version of the Colonial Fusion Reactor. Has increased energy output and can handle higher core temperatures. It is frequently used on Colonial Union military and police vessels.";
					InReactor.EnergyOutputMax = 17000f;
					InReactor.EnergySignatureAmt = 5f;
					InReactor.TempMax = 3000f;
					InReactor.EmergencyCooldownTime = 7f;
					InReactor.GetType().GetField("m_MarketPrice", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(InReactor, (ObscuredInt)5600);
					InReactor.CargoVisualPrefabID = 14;
					break;
				case (int)EReactorType.E_REAC_FB_MINI_REACTOR:
					InReactor.Name = "Fluffy Biscuit Jumbo Reactor";
					InReactor.Desc = "A standard reactor for Fluffy Biscuit Co. delivery ships. It produces a small output but is fairly difficult to detect.";
					InReactor.EnergyOutputMax = 12600f;
					InReactor.EnergySignatureAmt = 3f;
					InReactor.TempMax = 1800f;
					InReactor.EmergencyCooldownTime = 2f;
					InReactor.GetType().GetField("m_MarketPrice", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(InReactor, (ObscuredInt)1950);
					InReactor.CargoVisualPrefabID = 11;
					break;
				case (int)EReactorType.E_REAC_GTC_QUIET_CUPCAKE:
					InReactor.Name = "G.T.C. Quiet Cupcake";
					InReactor.Desc = "A modified Fluffy Biscuit Co. reactor also known as a murmur engine. It is an Alliance of Gentlemen favorite due to its small EM signature. If a crew does not want its presence known, this reactor will surely help in that endeavor.";
					InReactor.EnergyOutputMax = 14800f;
					InReactor.EnergySignatureAmt = 3f;
					InReactor.TempMax = 3500f;
					InReactor.EmergencyCooldownTime = 5f;
					InReactor.GetType().GetField("m_MarketPrice", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(InReactor, (ObscuredInt)2950);
					InReactor.CargoVisualPrefabID = 11;
					break;
				case (int)EReactorType.E_REAC_CU_FUSION_REACTOR_MK3:
					InReactor.Name = "Advanced Fusion Reactor";
					InReactor.Desc = "Superior version of the Military-Grade Fusion Reactor. Has increased energy output and can handle higher core temperatures. It is used on select ships in the Colonial Union Fleet.";
					InReactor.EnergyOutputMax = 22000f;
					InReactor.EnergySignatureAmt = 6f;
					InReactor.TempMax = 3200f;
					InReactor.EmergencyCooldownTime = 7f;
					InReactor.GetType().GetField("m_MarketPrice", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(InReactor, (ObscuredInt)10600);
					InReactor.CargoVisualPrefabID = 14;
					break;
				case (int)EReactorType.E_REAC_PF_ANTIMATTER_REACTOR:
					InReactor.Name = "P.F. Anti-Matter Reactor";
					InReactor.Desc = "Polytechnic Federation technology. These reactors were salvaged from destroyed P.F. vessels, studied, and recreated to work within the constraints of more common ships.";
					InReactor.EnergyOutputMax = 25000f;
					InReactor.EnergySignatureAmt = 7f;
					InReactor.TempMax = 2200f;
					InReactor.EmergencyCooldownTime = 5f;
					InReactor.GetType().GetField("m_MarketPrice", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(InReactor, (ObscuredInt)13800);
					InReactor.CargoVisualPrefabID = 15;
					break;
				case (int)EReactorType.ANCIENT_REACTOR:
					InReactor.Name = "Ancient Reactor";
					InReactor.Desc = "- NO INFO -";
					InReactor.EnergyOutputMax = 50000f;
					InReactor.EnergySignatureAmt = 1f;
					InReactor.TempMax = 4500f;
					InReactor.EmergencyCooldownTime = 5f;
					InReactor.GetType().GetField("m_MarketPrice", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(InReactor, (ObscuredInt)2550);
					InReactor.CanBeDroppedOnShipDeath = false;
					break;
				case (int)EReactorType.ROLAND_REACTOR:
					InReactor.Name = "Roland Reactor";
					InReactor.Desc = "Custom reactor built for a CU Roland-class starship. It is capable of large output and can function smoothly despite very high temperatures.";
					InReactor.EnergyOutputMax = 23000f;
					InReactor.EnergySignatureAmt = 8f;
					InReactor.TempMax = 3600f;
					InReactor.EmergencyCooldownTime = 10f;
					InReactor.GetType().GetField("m_MarketPrice", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(InReactor, (ObscuredInt)16000);
					InReactor.CargoVisualPrefabID = 14;
					InReactor.CanBeDroppedOnShipDeath = false;
					break;
				case (int)EReactorType.THERMOCORE_REACTOR:
					InReactor.Name = "ThermoCore Reactor";
					InReactor.Desc = "An experimental reactor that provides more power the hotter the core temperature. Due to high risk associated with this reactor, it has not been approved for standard commercial use.";
					InReactor.EnergyOutputMax = 38000f;
					InReactor.EnergySignatureAmt = 10f;
					InReactor.TempMax = 4500f;
					InReactor.EmergencyCooldownTime = 20f;
					InReactor.GetType().GetField("m_MarketPrice", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(InReactor, (ObscuredInt)56000);
					InReactor.CargoVisualPrefabID = 14;
					InReactor.HeatOutput = 1.6f;
					InReactor.Experimental = true;
					break;
				case (int)EReactorType.E_REAC_STRONGPOINT:
					InReactor.Name = "Strongpoint Reactor";
					InReactor.Desc = "High-performing reactor that links all the ship systems to boost output. Damaged ship systems will lower the output of the reactor.";
					InReactor.EnergyOutputMax = 24000f;
					InReactor.EnergySignatureAmt = 10f;
					InReactor.TempMax = 3200f;
					InReactor.EmergencyCooldownTime = 12f;
					InReactor.GetType().GetField("m_MarketPrice", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(InReactor, (ObscuredInt)13600);
					InReactor.CargoVisualPrefabID = 14;
					InReactor.Experimental = true;
					break;
				case (int)EReactorType.E_LEAKING_REACTOR:
					InReactor.Name = "Leaky Reactor";
					InReactor.Desc = "Powerful reactor that occasionally spews radiation. Label reads “DO NOT USE”.";
					InReactor.EnergyOutputMax = 21000f;
					InReactor.EnergySignatureAmt = 14f;
					InReactor.TempMax = 3900f;
					InReactor.EmergencyCooldownTime = 10f;
					InReactor.GetType().GetField("m_MarketPrice", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(InReactor, (ObscuredInt)8600);
					InReactor.CargoVisualPrefabID = 14;
					InReactor.Experimental = true;
					break;
				case (int)EReactorType.E_SYLVASSI_REACTOR:
					InReactor.Name = "Sylvassi Reactor";
					InReactor.Desc = "A competent reactor with a lower maximum temperature. It is usually used on refurbished Sylvassi ships.";
					InReactor.EnergyOutputMax = 20000f;
					InReactor.EnergySignatureAmt = 4f;
					InReactor.TempMax = 1400f;
					InReactor.HeatOutput = 0.85f;
					InReactor.EmergencyCooldownTime = 10f;
					InReactor.GetType().GetField("m_MarketPrice", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(InReactor, (ObscuredInt)8600);
					InReactor.CargoVisualPrefabID = 14;
					break;
				case 15:
					InReactor.Name = "Dragon Reactor";
					InReactor.Desc = "Test Reactor";
					InReactor.EnergyOutputMax = 200000f;
					InReactor.EnergySignatureAmt = 1f;
					InReactor.TempMax = 4000f;
					InReactor.HeatOutput = 0.5f;
					InReactor.EmergencyCooldownTime = 3f;
					InReactor.GetType().GetField("m_MarketPrice", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(InReactor, (ObscuredInt)100000);
					InReactor.CargoVisualPrefabID = 14;
					break;
			}
			InReactor.GetType().GetField("OriginalEnergyOutputMax", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(InReactor, InReactor.EnergyOutputMax);
			return InReactor;
		}
}
}
