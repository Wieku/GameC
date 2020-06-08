using System.Collections.Generic;

namespace Game.Engine.Interactions.Custom.CarrotStates
{
    class CarrotStateBlooming: CarrotStateCollectable
    {
        public CarrotStateBlooming(CarrotInteraction carrot, GameSession session) : base(carrot, session)
        {
        }

        public override bool Execute()
        {
            session.SendText("This carrot appears to be grown, do you want to collect it?");
            
            var choice = session.ListBoxInteractionChoice(new List<string>() { "Collect it!", "Allow it to grow more." });
            switch (choice)
            {
                case 0:
                    Collect();

                    if (carrot.timesGrown >= CarrotInteraction.SoilDurability)
                        carrot.carrotState = new CarrotStateSoilDepleted(carrot, session);
                    else
                    {
                        session.SendText("You have seeds, do you want to plant them?");
            
                        var choice2 = session.ListBoxInteractionChoice(new List<string>() { "Sure!", "Nah, I want to keep them." });

                        switch (choice2)
                        {
                            case 0:
                                carrot.carrotState = new CarrotStateGrowing(carrot, session);
                                return true;
                            
                            default:
                                carrot.carrotState = new CarrotStateSoilEmpty(carrot, session);
                                break;      
                        }
                    }

                    break;
                default:
                    session.SendText("You walk away allowing carrots to rot."); //TODO: Carrot rotting
                    break;
            }

            return false;
        }
    }
}