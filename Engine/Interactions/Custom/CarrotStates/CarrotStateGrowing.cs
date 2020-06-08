namespace Game.Engine.Interactions.Custom.CarrotStates
{
    class CarrotStateGrowing : CarrotState
    {
        private bool wasRunOnce = false;
        private bool wasRunTwice = false;
            
        public CarrotStateGrowing(CarrotInteraction carrot, GameSession session) : base(carrot, session)
        {
        }

        public override bool Execute()
        {
            if (!wasRunOnce)
            {
                carrot.timesGrown++;
                wasRunOnce = true;

                return false;
            }

            if (!wasRunTwice)
            {
                session.SendText("It's not grown yet...");
                wasRunTwice = true;
            }
            else
            {
                carrot.carrotState = new CarrotStateGrown(carrot, session);
                return true;
            }
            
            return false;
        }
    }
}