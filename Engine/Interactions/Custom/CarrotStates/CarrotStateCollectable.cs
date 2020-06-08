using Game.Engine.Items.Custom;
using Game.Engine.Monsters;

namespace Game.Engine.Interactions.Custom.CarrotStates
{
    abstract class CarrotStateCollectable : CarrotState
    {
        protected CarrotStateCollectable(CarrotInteraction carrot, GameSession session) : base(carrot, session)
        {
        }

        protected void Collect()
        {
            session.SendText("You collected some carrots!");
            session.AddThisItem(new Carrot());
            session.AddThisItem(new Carrot());
            
            var randomRat = Index.RNG(0, 2) == 0;

            if (randomRat)
            {
                session.SendText("Unfortunately under the carrot there was a tunnel occupied by rat and it got angry!");
                session.FightThisMonster(new Rat(session.currentPlayer.Level));
            }

        }

    }
}