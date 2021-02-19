using UnityEngine;

namespace DragonReactor.MissionShipComponent
{
    public abstract class MissionShipComponentPlugin
    {
        public MissionShipComponentPlugin()
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
        public virtual Texture2D IconTexture
        {
            get { return (Texture2D)Resources.Load("defaultShipCompIcon"); }
        }
        public virtual int MarketPrice
        {
            get { return 10000; }
        }
        public virtual int CargoVisualID
        {
            get { return 7; }
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
