using System.Collections.Generic;

namespace Game.Engine.Interactions.Custom.CarrotStates
{
    class CarrotStateGrown: CarrotStateCollectable
    {
        public CarrotStateGrown(CarrotInteraction carrot, GameSession session) : base(carrot, session)
        {
        }

        public override bool Execute()
        {
            //TODO: Blooming
            session.SendText("This carrot appears to be grown, do you want to collect it?");
            
            var choice = session.ListBoxInteractionChoice(new List<string>() { "Collect it!", "Allow it to grow more." });
            switch (choice)
            {
                case 0:
                    Collect();

                    if (carrot.timesGrown >= CarrotInteraction.SoilDurability)
                        carrot.carrotState = new CarrotStateSoilDepleted(carrot, session);
                    else
                        carrot.carrotState = new CarrotStateSoilEmpty(carrot, session);

                    return true;
                default:
                    session.SendText("You walk away allowing carrots to bloom.");
                    break;
            }

            return false;
        }
    }
}