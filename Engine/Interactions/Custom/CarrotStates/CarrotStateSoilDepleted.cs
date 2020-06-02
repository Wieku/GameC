namespace Game.Engine.Interactions.Custom.CarrotStates
{
    class CarrotStateSoilDepleted: CarrotState
    {
        public CarrotStateSoilDepleted(CarrotInteraction carrot, GameSession session) : base(carrot, session)
        {
        }

        public override bool Execute()
        {
            session.SendText("Sorry, but soil is depleted, you cannot plant carrots here anymore.");

            return false;
        }
    }
}