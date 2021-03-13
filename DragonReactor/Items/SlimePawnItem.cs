using UnityEngine;

namespace DragonReactor.Items
{
    class SlimePawnItem : ItemPlugin
    {
        public override string Name => "Slime";

        public override PLPawnItem PLPawnItem => new Slime();
    }
    class Slime : PLPawnItem_Food
    {
        public Slime() : base(EFoodType.MAX)
        {
            HealAmt = 100;
            Desc = "I want to slide down your throat";
        }

        public override string GetItemName()
        {
            return "Slime";
        }
        public override GameObject GetVisualPrefab()
        {
            return PLGlobal.Instance.FoodPrefabs[25];
        }
    }
}

