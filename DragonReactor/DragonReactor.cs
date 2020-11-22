namespace DragonReactor
{
    class DragonReactor : ReactorPlugin
    {
        public override string Name => "Dragon Reactor V0.1.0";

        public override string Description => "= NO - INFO =";

        public override float EnergyOutputMax => 30000f;

        public override float EnergySignatureAmount => 1f;

        public override float MaxTemp => 10f;

        public override float EmergencyCooldownTime => 30f;

        public override int MarketPrice => 10;

        public override bool Experimental => true;
    }
}
