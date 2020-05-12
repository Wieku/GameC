using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    class OrcFactory : MonsterFactory
    {
        // this factory produces rats (or evolved rats)

        private bool boss = false;
        private bool alreadySpawned = false;

        public override Monster Create(int playerLevel)
        {
            if (alreadySpawned)
                return null;

            alreadySpawned = true;
            
            return boss ? (Monster) new OrcShaman(playerLevel) : new OrcWarrior(playerLevel);
        }
        public override System.Windows.Controls.Image Hint()
        {
            boss = Index.RNG(0, 5) == 0; //We need to do it here, because Hint is called before Create
            if (alreadySpawned) return null;
            return boss ? new OrcShaman(0).GetImage() : new OrcWarrior(0).GetImage();
        }
    }
}
