namespace EventSystem
{
    public class GlobalEventsList
    {
        public readonly StartGameEvent startGameEvent 
            = new StartGameEvent();
    }
    
    public class StartGameEvent : GameEvent
    {
    }
}