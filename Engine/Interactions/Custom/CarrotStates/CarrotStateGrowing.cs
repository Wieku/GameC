namespace Game.Engine.Interactions.Custom.CarrotStates
{
    class CarrotStateGrowing : CarrotState
    {
        private bool wasRunOnce = false;
            
        public CarrotStateGrowing(CarrotInteraction carrot, GameSession session) : base(carrot, session)
        {
        }

        public override bool Execute()
        {
            if (!wasRunOnce)
            {
                carrot.timesGrown++;
                wasRunOnce = true;
            }

            //TODO: Carrot grow
            
            return false;
        }
    }
}