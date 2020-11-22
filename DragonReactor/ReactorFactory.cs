using System.Reflection;
using CodeStage.AntiCheat.ObscuredTypes;

namespace DragonReactor
{
    class ReactorFactory
	{
		//public static ReactorFactory[] ReactorTypes;
		/*private string Name;
		private string Description;
		private float EnergyOutputMax;
		private float EnergySignatureAmount;
		private float MaxTemp;
		private float EmergencyCooldownTime;
		private int MarketPrice;
		private int CargoVisualID;
		private bool CanBeDroppedOnShipDeath;
		private bool Experimental;*/
		/*private ReactorFactory(string Name, string Description, float EnergyOutputMax, float EnergySignatureAmount, float MaxTemp, float EmergencyCooldownTime = 10f, int MarketPrice = 2100, int CargoVisualID = 11, bool CanBeDroppedOnShipDeath = true, bool Experimental = false)
        {
			this.Name = Name;
			this.Description = Description;
			this.EnergyOutputMax = EnergyOutputMax;
			this.EnergySignatureAmount = EnergySignatureAmount;
			this.MaxTemp = MaxTemp;
			this.EmergencyCooldownTime = EmergencyCooldownTime;
			this.MarketPrice = MarketPrice;
			this.CargoVisualID = CargoVisualID;
			this.CanBeDroppedOnShipDeath = CanBeDroppedOnShipDeath;
			this.Experimental = Experimental;
        }*/
		/*public static void AddReactor(string Name, string Description, float EnergyOutputMax, float EnergySignatureAmount, float MaxTemp, float EmergencyCooldownTime = 10f, int MarketPrice = 2100, int CargoVisualID = 11, bool CanBeDroppedOnShipDeath = true, bool Experimental = false)
        {
			ReactorTypes[ReactorTypes.Length -1] = new ReactorFactory(Name, Description, EnergyOutputMax, EnergySignatureAmount, MaxTemp, EmergencyCooldownTime, MarketPrice, CargoVisualID, CanBeDroppedOnShipDeath, Experimental);
        }*/
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
			if(InReactor.SubType == 7)
            {
				InReactor.SubType = Subtype;
				ReactorFactory PluginReactor = ReactorTypes[Subtype - 15];
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
				//InReactor.Contraband = PluginReactor.
				InReactor.GetType().GetField("OriginalEnergyOutputMax", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(InReactor, InReactor.EnergyOutputMax);
			}
			return InReactor;
		}
}
}
