namespace DragonReactor
{
    public abstract class HullPlugin
    {
        public HullPlugin()
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
        public virtual float HullMax
        {
            get { return 750f; }
        }
        public virtual float Armor
        {
            get { return .15f; }
        }
        public virtual float Defense
        {
            get { return .2f; }
        }
        public virtual int MarketPrice
        {
            get { return 1550; }
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
    }
}
