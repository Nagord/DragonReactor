namespace DragonReactor
{
    public abstract class CaptainsChairPlugin
    {
        public CaptainsChairPlugin()
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
        public virtual int MarketPrice
        {
            get { return 1200; }
        }
        public virtual int CargoVisualID
        {
            get { return 1; }
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
        public virtual void LateAddStats(PLShipStats InStats)
        {
            
        }
    }
}
