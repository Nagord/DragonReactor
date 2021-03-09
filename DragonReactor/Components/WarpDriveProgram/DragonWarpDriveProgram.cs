namespace DragonReactor.Components.WarpDriveProgram
{
    class DragonWarpDriveProgram : WarpDriveProgramPlugin
    {
        public override string Name => "Dragon WarpDriveProgram";

        public override string Description => "Who knows?";

        public override bool Experimental => true;

        public override void FinalLateAddStats(PLWarpDriveProgram InWarpDriveProgram)
        {
            InWarpDriveProgram.ShipStats.EMDetection *= 1f + .1f * InWarpDriveProgram.LevelMultiplier(0.2f, 1f);
            InWarpDriveProgram.ShipStats.ShieldsChargeRate *= 1f + .1f * InWarpDriveProgram.LevelMultiplier(0.2f, 1f);
            InWarpDriveProgram.ShipStats.ShieldsChargeRateMax *= 1f + .1f * InWarpDriveProgram.LevelMultiplier(0.2f, 1f);
            InWarpDriveProgram.ShipStats.TurretChargeFactor *= 1f + .1f * InWarpDriveProgram.LevelMultiplier(0.2f, 1f);
        }
        public override void Execute(PLWarpDriveProgram InWarpDriveProgram)
        {
            InWarpDriveProgram.ShipStats.ShieldsCurrent = 0f;
        }
    }
}
