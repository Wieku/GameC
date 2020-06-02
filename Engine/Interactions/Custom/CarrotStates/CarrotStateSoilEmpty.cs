using System.Collections.Generic;

namespace Game.Engine.Interactions.Custom.CarrotStates
{
    class CarrotStateSoilEmpty: CarrotState
    {
        public CarrotStateSoilEmpty(CarrotInteraction carrot, GameSession session) : base(carrot, session)
        {
        }

        public override bool Execute()
        {
            session.SendText("This soil is empty.");

            var result = session.TestForItemInInventory("item2165");

            if (!result) return false;
            
            session.SendText("It seems you have a spare carrot, do you want to plant it?");
            
            var choice = session.ListBoxInteractionChoice(new List<string>() { "Sure!", "My presiousssss..." });
            switch (choice)
            {
                case 0:
                    session.RemoveItemFromInventory("item2165");
                    carrot.carrotState = new CarrotStateGrowing(carrot, session);
                    return true;
                default:
                    session.SendText("You walk away allowing carrots in your inventory to rot...");
                    break;
            }

            return false;
        }
    }
}