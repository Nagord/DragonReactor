using UnityEngine;

namespace DragonReactor.Components.Extractor
{
    public abstract class ExtractorPlugin
    {
        public ExtractorPlugin()
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
        public virtual float Stability
        {
            get { return 1f; }
        }
        public virtual int MarketPrice
        {
            get { return 3200; }
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
