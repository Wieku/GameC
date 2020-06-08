using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.Interactions.Custom;

namespace Game.Engine.Interactions.InteractionFactories
{
    [Serializable]
    class CarrotFarmerOldManFactory : InteractionFactory
    {
        public List<Interaction> CreateInteractionsGroup(GameSession parentSession)
        {
            var interactions = new List<Interaction>();
            FarmerEncounter farmer = new FarmerEncounter(parentSession);
            OldManEncounter oldMan = new OldManEncounter(farmer, parentSession);
            
            interactions.Add(farmer);
            interactions.Add(oldMan);

            for (int i = 0; i < 20; i++)
            {
                interactions.Add(new CarrotInteraction(oldMan, parentSession));
            }

            return interactions;
        }
    }
}
