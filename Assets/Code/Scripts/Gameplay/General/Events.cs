namespace GalconTechDemo.Gameplay
{
    public static class Events
    {
        public static GameStartedEvent OnGameStartedEvent = new GameStartedEvent();
        public static PlanetsGeneratedEvent PlanetsGeneratedEvent = new PlanetsGeneratedEvent();
    }

    public class GameStartedEvent : GameEvent
    {
        public GameConfig gameConfig;
    }

    public class PlanetsGeneratedEvent : GameEvent { };
}