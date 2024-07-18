namespace DefaultNamespace
{
    public static class Events
    {
        public delegate void Scored(int newScore);
        public static event Scored ScoredEvent;
        
        public delegate void Turned(int newTurnCount);
        public static event Turned TurnedEvent;
        
        public delegate void FlippedCard();
        public static event FlippedCard FlippedCardEvent;
        
        public delegate void Missed();
        public static event Missed MissedEvent;
        
        public delegate void Win();
        public static event Win WinEvent;

        public static void InvokeScoredEvent(int newScore)
        {
            ScoredEvent?.Invoke(newScore);
        }
        
        public static void InvokeTurnedEvent(int newTurnCount)
        {
            TurnedEvent?.Invoke(newTurnCount);
        }
        
        public static void InvokeFlippedCardEvent()
        {
            FlippedCardEvent?.Invoke();
        }
        
        public static void InvokeMissedEvent()
        {
            MissedEvent?.Invoke();
        }
        
        public static void InvokeWinEvent()
        {
            WinEvent?.Invoke();
        }
    }
}