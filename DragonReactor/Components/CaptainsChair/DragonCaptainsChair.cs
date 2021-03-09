namespace DragonReactor.Components.CaptainsChair
{
    class DragonCaptainsChair : CaptainsChairPlugin
    {
        public override string Name => "Dragon CaptainsChair";

        public override string Description => "A design of chair that has been installed in Colonial Union ships for many decades. It is quite comfortable. \n\n+10% EM Detection\n+10% Shield Charge Rate\n+10% Turret Charge Rate";

        public override void LateAddStats(PLShipStats InStats)
        {
            InStats.EMDetection *= 1.1f;
            InStats.ShieldsChargeRate *= 1.1f;
            InStats.ShieldsChargeRateMax *= 1.1f;
            InStats.TurretChargeFactor *= 1.1f;
        }
    }
}
