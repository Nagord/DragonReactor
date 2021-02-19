using UnityEngine;

namespace DragonReactor.CPU
{
    class DragonCPU : CPUPlugin
    {
        public override string Name => "Dragon CPU";

        public override string Description => "Who knows?";

        public override bool Experimental => true;

        public override float MaxPowerUsage_Watts => 10000f;

        public override void AddStats(PLCPU InCPU)
        {
            InCPU.ShipStats.TurretDamageFactor *= 1000f * InCPU.LevelMultiplier(1f, 1f) * InCPU.GetPowerPercentInput();
        }

        public override void FinalLateAddStats(PLCPU InCPU)
        {
            InCPU.ShipStats.EMDetection *= 1f + .1f * InCPU.LevelMultiplier(0.2f, 1f);
            InCPU.ShipStats.ShieldsChargeRate *= 1f + .1f * InCPU.LevelMultiplier(0.2f, 1f);
            InCPU.ShipStats.ShieldsChargeRateMax *= 1f + .1f * InCPU.LevelMultiplier(0.2f, 1f);
            InCPU.ShipStats.TurretChargeFactor *= 1f + .1f * InCPU.LevelMultiplier(0.2f, 1f);
        }

        public override string GetStatLineLeft(PLCPU InCPU)
        {
            return "EM Detection";
        }

        public override string GetStatLineRight(PLCPU InCPU)
        {
            return "+" + (10f * InCPU.LevelMultiplier(2f, 1f)).ToString("0.0") + "%";
        }

        public override void Tick(PLCPU InCPU)
        {
            Mathf.Clamp01(InCPU.ShipStats.Ship.ReactorCoolantLevelPercent += .001f);
        }

        public override void WhenProgramIsRun(PLWarpDriveProgram inProgram)
        {
            PulsarPluginLoader.Utilities.Messaging.Notification("WarpdProgram thing running because of " + inProgram.Name);
        }
    }
}
