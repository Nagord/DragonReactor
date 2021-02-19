
namespace DragonReactor.HullPlating
{
    class DragonHullPlatingPlugin : HullPlatingPlugin
    {
        public override PLShipComponent PLHullPlating => new DragonHullPlating();

        public override string Name => "DragonHullPlating";
    }
    public class DragonHullPlating : PLHullPlating
    {
        public DragonHullPlating(int inLevel = 0, int inSubTypeData = 1) : base(EHullPlatingType.E_HULLPLATING_CCGE, 0)
        {
            SubType = HullPlatingPluginManager.Instance.GetHullPlatingIDFromName("DragonHullPlating");
            Name = "DragonHullPlating";
            Desc = "a hull plating, nothing special.";
            m_MarketPrice = 100000;
            Experimental = true;
            Level = inLevel;
            SubTypeData = (short)inSubTypeData;
        }
    }
}
