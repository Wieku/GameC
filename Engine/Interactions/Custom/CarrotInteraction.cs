using Game.Engine.Interactions.Custom.CarrotStates;

namespace Game.Engine.Interactions.Custom
{
    class CarrotInteraction: ListBoxInteraction
    {
        public const int SoilDurability = 3;

        internal ICarrotState carrotState;

        internal int timesGrown = 1;
        
        public CarrotInteraction(GameSession ses) : base(ses)
        {
            Name = "interaction2161";
            
            switch (Index.RNG(0, 3))
            {
                case 0:
                    carrotState = new CarrotStateGrowing(this, ses);
                    break;
                case 1:
                    carrotState = new CarrotStateGrown(this, ses);
                    break;
                default:
                    carrotState = new CarrotStateBlooming(this, ses);
                    break;
            }
        }

        protected override void RunContent()
        {
            while (carrotState.Execute());
        }
    }
}