using UnityEngine;

namespace DragonReactor.Components.WarpDrive
{
    public abstract class WarpDrivePlugin
    {
        public WarpDrivePlugin()
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
            get { return (Texture2D)Resources.Load("Icons/17_Warp"); }
        }
        public virtual float ChargeSpeed
        {
            get { return 3.3f; }
        }
        public virtual float WarpRange
        {
            get { return .06f; }
        }
        public virtual float EnergySignature
        {
            get { return 8f; }
        }
        public virtual int NumberOfChargesPerFuel
        {
            get { return 3; }
        }
        public virtual int MarketPrice
        {
            get { return 1800; }
        }
        public virtual int CargoVisualID
        {
            get { return 16; }
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
