namespace Game.Engine.Interactions.Custom.CarrotStates
{
    abstract class CarrotStateCollectable : CarrotState
    {
        protected CarrotStateCollectable(CarrotInteraction carrot, GameSession session) : base(carrot, session)
        {
        }

        protected void Collect()
        {
            
        }

    }
}