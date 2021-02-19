namespace DragonReactor.NuclearDevice
{
    class DragonNuclearDevice : NuclearDevicePlugin
    {
        public override string Name => "Dragon NuclearDevice";

        public override float MaxDamage => 100000f;

        public override float Range => 1000f;

        public override float FuelBurnRate => 2.5f;

        public override float TurnRate => 1f;

        public override float IntimidationBonus => 1000f;

        public override float Health => 100000f;
    }
}
