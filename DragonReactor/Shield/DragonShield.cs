namespace DragonReactor.Shield
{
    class DragonShield : ShieldPlugin
    {
        public override string Name => "Dragon Shield";

        public override float ShieldMax => 100000f;

        public override float ChargeRateMax => 100f;

        public override float RecoveryRate => 0f;

        public override float Deflection => 1f;

        public override float MinIntegrityPercentForQuantumShield => .01f;

        public override float MaxPowerUsage_Watts => 1000f;

        public override int MinIntegrityAfterDamage => 1000;
    }
}
