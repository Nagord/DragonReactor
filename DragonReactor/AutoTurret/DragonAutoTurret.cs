namespace DragonReactor.AutoTurret
{
    class DragonAutoTurretPlugin : AutoTurretPlugin
    {
        public override PLShipComponent PLAutoTurret => new DragonAutoTurret();

        public override string Name => "MegaDragonCannon";
    }
    public class DragonAutoTurret : PLAutoTurret
    {
        public DragonAutoTurret(int inLevel = 0, int inSubTypeData = 1) : base(0)
        {
            SubType = AutoTurretPluginManager.Instance.GetAutoTurretIDFromName("DragonAutoTurret");
            Name = "DragonAutoTurret";
            Desc = "MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm";
            m_Damage = 10f;
            m_MarketPrice = 10000;
            m_MaxPowerUsage_Watts = 1000f;
            FireDelay = 0.1f;
            HeatGeneratedOnFire = 0f;
            CargoVisualPrefabID = 3;
            TurretRange = 20000f;
            AutoAimPowerUsageRequest = 1f;
            m_SlotType = ESlotType.E_COMP_AUTO_TURRET;
            Experimental = true;
            Level = inLevel;
            SubTypeData = (short)inSubTypeData;
        }
    }
}
