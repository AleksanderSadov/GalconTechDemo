namespace GalconTechDemo.Gameplay
{
    public static class Events
    {
        public static GameStartedEvent OnGameStartedEvent = new GameStartedEvent();
        public static PlanetsGeneratedEvent PlanetsGeneratedEvent = new PlanetsGeneratedEvent();
        public static PlanetSelectedEvent PlanetSelectedEvent = new PlanetSelectedEvent();
    }

    public class GameStartedEvent : GameEvent
    {
        public GameConfig gameConfig;
    }

    public class PlanetsGeneratedEvent : GameEvent { };

    public class PlanetSelectedEvent : GameEvent
    {
        public Planet planet;
    }
}