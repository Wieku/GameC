namespace Game.Engine.Interactions.Custom.CarrotStates
{
    public interface ICarrotState
    {
        /// <summary>
        /// Executes this state
        /// </summary>
        /// <param name="session"></param>
        /// <returns>should the state be rerun</returns>
        bool Execute();
    }
}