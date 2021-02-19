using UnityEngine;

namespace DragonReactor.Missile
{
    public abstract class MissilePlugin
    {
        public MissilePlugin()
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
            get { return (Texture2D)Resources.Load("Icons/62_Processer"); }
        }
        public virtual float Damage
        {
            get { return 360f; }
        }
        public virtual float Speed
        {
            get { return 12f; }
        }
        public virtual EDamageType DamageType
        {
            get { return EDamageType.E_PHYSICAL; }
        }
        public virtual int MissileRefillPrice
        {
            get { return 80; }
        }
        public virtual int AmmoCapacity
        {
            get { return 40; }
        }
        public virtual int PrefabID
        {
            get { return 0; }
        }
        public virtual int MarketPrice
        {
            get { return 2500; }
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
