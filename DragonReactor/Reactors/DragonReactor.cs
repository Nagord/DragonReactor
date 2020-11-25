using UnityEngine;

namespace DragonReactor
{
    class DragonReactor : ReactorPlugin
    {
        public override string Name => "Dragon Reactor";

        public override string Description => "= NO - INFO =";

        public override float EnergyOutputMax => 30000f;

        public override float EnergySignatureAmount => 1f;

        public override float HeatOutput => 1.78f;

        public override float MaxTemp => 2500f;

        public override float EmergencyCooldownTime => 30f;

        public override int MarketPrice => 10;

        public override bool Experimental => true;

        public override void ReactorPowerCode(PLReactor ReactorInstance)
        {
            ReactorInstance.EnergyOutputMax = EnergyOutputMax * (1-Mathf.Clamp(ReactorInstance.ShipStats.ReactorTempCurrent / ReactorInstance.ShipStats.ReactorTempMax, .0f, .95f));
        }
    }
}
