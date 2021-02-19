using UnityEngine;

namespace DragonReactor.Turret
{
    class DragonTurretPlugin : TurretPlugin
    {
        public override PLShipComponent PLTurret => new DragonTurret();

        public override string Name => "MegaDragonCannon";
    }
    public class DragonTurret : PLLaserTurret
    {
        public DragonTurret(int inLevel = 0, int inSubTypeData = 1) : base(0)
        {
            SubType = TurretPluginManager.Instance.GetTurretIDFromName("MegaDragonCannon");
            Name = "MegaDragonCannon";
            Desc = "MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm";
            m_Damage = 500f;
            m_MarketPrice = 10000;
            m_MaxPowerUsage_Watts = 1000f;
            FireDelay = 10f;
            CargoVisualPrefabID = 3;
            TurretRange = 20000f;
            m_KickbackForceMultiplier = 1000f;
            AutoAimEnabled = true;
            IsMainTurret = false;
            HasTrackingMissileCapability = false;
            Experimental = true;
            m_AutoAimMinDotPrd = 1f;
            Level = inLevel;
            SubTypeData = (short)inSubTypeData;
        }
    }
}
