namespace DragonReactor
{
    public abstract class ReactorPlugin
    {
        public virtual string Name
        {
            get { return ""; }
        }
        public virtual string Description
        {
            get { return ""; }
        }
        public virtual float EnergyOutputMax
        {
            get { return 15000f; }
        }
        public virtual float EnergySignatureAmount
        {
            get { return 18f; }
        }
        public virtual float MaxTemp
        {
            get { return 1800f; }
        }
        public virtual float EmergencyCooldownTime
        {
            get { return 20f; }
        }
        public virtual int MarketPrice
        {
            get { return 2100; }
        }
        public virtual int CargoVisualID
        {
            get { return 11; }
        }
        public virtual bool CanBeDroppedOnShipDeath
        {
            get { return true; }
        }
        public virtual bool Experimental
        {
            get { return false; }
        }
        public virtual bool Contraband
        {
            get { return false; }
        }

        public virtual void ReactorPowerCode()
        {

        }
    }
}
