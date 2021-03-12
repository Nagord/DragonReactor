using UnityEngine;

namespace DragonReactor.Items
{
    class PizzaPawnItemPlugin : ItemPlugin
    {
        public override string Name => "Pizza";

        public override PLPawnItem PLPawnItem => new PizzaPawnItem();
    }
    class PizzaPawnItem : PLPawnItem_Food
    {
        public PizzaPawnItem() : base((EFoodType.MAX))
        {
            HealAmt = 50f;
            m_Desc = "Bobs your uncle and I'm a pizza.";
        }
        public override string GetItemName()
        {
            return "Pizza";
        }
        public override GameObject GetVisualPrefab()
        {
            return PLGlobal.Instance.FoodPrefabs[25];
        }
    }
}
