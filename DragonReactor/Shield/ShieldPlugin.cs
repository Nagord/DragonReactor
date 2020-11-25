namespace DragonReactor
{
    public abstract class ShieldPlugin
    {
        public ShieldPlugin()
        {
        }
        public virtual string Name
        {
            get { return ""; }
        }
        public virtual string Description
        {
            get { return ""; }
        }
        public virtual float ShieldMax
        {
            get { return 70f; }
        }
        public virtual float ChargeRateMax
        {
            get { return 12f; }
        }
        public virtual float RecoveryRate
        {
            get { return 15f; }
        }
        public virtual float Deflection
        {
            get { return 1f; }
        }
        public virtual float MinIntegrityPercentForQuantumShield
        {
            get { return .9f; }
        }
        public virtual float MaxPowerUsage_Watts
        {
            get { return 4600; }
        }
        public virtual int MinIntegrityAfterDamage
        {
            get { return -1; }
        }
        public virtual int MarketPrice
        {
            get { return 1200; }
        }
        public virtual int CargoVisualID
        {
            get { return 39; }
        }
        public virtual bool CanBeDroppedOnShipDeath
        {
            get { return true; }
        }
        public virtual bool Experimental
        {
            get { return false; }
        }
        public virtual bool Unstable
        {
            get { return false; }
        }
        public virtual bool Contraband
        {
            get { return false; }
        }
    }
}
