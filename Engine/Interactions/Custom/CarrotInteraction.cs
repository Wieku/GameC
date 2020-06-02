using Game.Engine.Interactions.Custom.CarrotStates;

namespace Game.Engine.Interactions.Custom
{
    class CarrotInteraction: ListBoxInteraction
    {
        protected const int SoilDurability = 3;

        private ICarrotState carrotState;

        protected int timesGrown = 1;
        
        public CarrotInteraction(GameSession ses) : base(ses)
        {
            
        }

        protected override void RunContent()
        {
            while (carrotState.Execute());
        }
    }
}