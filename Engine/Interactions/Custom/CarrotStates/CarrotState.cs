namespace Game.Engine.Interactions.Custom.CarrotStates
{
    abstract class CarrotState : ICarrotState
    {
        protected CarrotInteraction carrot;
        protected GameSession session;

        public CarrotState(CarrotInteraction carrot, GameSession session)
        {
            this.carrot = carrot;
            this.session = session;
        }

        public abstract bool Execute();
    }
}