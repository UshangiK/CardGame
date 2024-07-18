namespace DefaultNamespace
{
    public static class Events
    {
        public delegate void Scored(int newScore);
        public static event Scored ScoredEvent;
        
        public delegate void Turned(int newTurnCount);
        public static event Turned TurnedEvent;

        public static void InvokeScoredEvent(int newScore)
        {
            ScoredEvent?.Invoke(newScore);
        }
        
        public static void InvokeTurnedEvent(int newTurnCount)
        {
            TurnedEvent?.Invoke(newTurnCount);
        }
    }
}