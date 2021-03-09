using UnityEngine;

namespace DragonReactor.Components.MegaTurret
{
    class DragonMegaTurretPlugin : MegaTurretPlugin
    {
        public override PLShipComponent PLMegaTurret => new DragonMegaTurret();

        public override string Name => "MegaDragonCannon";
    }
    public class DragonMegaTurret : PLMegaTurret
    {
        public DragonMegaTurret(int inLevel = 0, int inSubTypeData = 1) : base(0)
        {
            SubType = MegaTurretPluginManager.Instance.GetMegaTurretIDFromName("MegaDragonCannon");
            Name = "MegaDragonCannon";
            Desc = "MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm";
            m_Damage = 999999999f;
            m_MarketPrice = 100000;
            m_MaxPowerUsage_Watts = 1000f;
            FireDelay = 20f;
            CargoVisualPrefabID = 5;
            TurretRange = 20000f;
            BeamColor = new UnityEngine.Color(0f, 0f, 0f);
            MegaTurretExplosionID = 1;
            m_KickbackForceMultiplier = 1000f;
            AutoAimEnabled = true;
            IsMainTurret = true;
            HasTrackingMissileCapability = false;
            DamageType = EDamageType.E_SEEKERBLADE;
            Experimental = true;
            m_AutoAimMinDotPrd = 1f;
            Level = inLevel;
            SubTypeData = (short)inSubTypeData;
        }
        public override void Fire(int inProjID, Vector3 dir)
        {
            this.ShipStats.Ship.EngineeringSystem.Health = 0f;
            base.Fire(inProjID, dir);
        }
    }
}
