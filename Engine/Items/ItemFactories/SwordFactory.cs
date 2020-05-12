using System;
using System.Collections.Generic;
using Game.Engine.Items.Swords;

namespace Game.Engine.Items.ItemFactories
{
    [Serializable]
    class SwordFactory : ItemFactory
    {
        // produce items from Sword directory
        public Item CreateItem()
        {
            List<Item> swords = new List<Item>()
            {
                new Aerondight(),
                new Anferthe(),
            };
            return swords[Index.RNG(0, swords.Count)];
        }
        public Item CreateNonMagicItem()
        {
            var rng = Index.RNG(0, 100);
            return rng < 3 ? (Item) new Aerondight() : (rng < 18 ? (Item) new Anferthe() : (rng < 36 ? new Deargdeith() : null)); //Aerondight: 3% chance of drop, Anferthe and Deargeith: 18%
        }

        public Item CreateNonWeaponItem()
        {
            return null;
        }
    }
}
