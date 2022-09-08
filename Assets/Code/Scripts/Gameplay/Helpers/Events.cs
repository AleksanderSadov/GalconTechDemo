namespace GalconTechDemo.Gameplay
{
    public static class Events
    {
        public static GameStartedEvent OnGameStartedEvent = new GameStartedEvent();
        public static PlanetsGeneratedEvent PlanetsGeneratedEvent = new PlanetsGeneratedEvent();
        public static PlanetClickedEvent PlanetClickedEvent = new PlanetClickedEvent();
        public static PlanetSelectedEvent PlanetSelectedEvent = new PlanetSelectedEvent();
        public static PlanetDeselectedEvent PlanetDeselectedEvent = new PlanetDeselectedEvent();
        public static PlanetEnterHoverEvent PlanetEnterHoverEvent = new PlanetEnterHoverEvent();
        public static PlanetExitHoverEvent PlanetExitHoverEvent = new PlanetExitHoverEvent();
        public static PlaneClickedEvent PlaneClicked = new PlaneClickedEvent();
        public static AttackPlanetEvent AttackPlanetEvent = new AttackPlanetEvent();
    }

    public class GameStartedEvent : GameEvent
    {
        public GameConfig gameConfig;
    }

    public class PlanetsGeneratedEvent : GameEvent { };

    public class PlanetClickedEvent : GameEvent
    {
        public Planet planet;
    }

    public class PlanetSelectedEvent : GameEvent
    {
        public Planet planet;
    }

    public class PlanetDeselectedEvent : GameEvent
    {
        public Planet planet;
    }

    public class PlanetEnterHoverEvent : GameEvent
    {
        public Planet planet;
    }

    public class PlanetExitHoverEvent : GameEvent
    {
        public Planet planet;
    }

    public class PlaneClickedEvent : GameEvent { }

    public class AttackPlanetEvent : GameEvent
    {
        public Planet attackerPlanet;
        public Planet defenderPlanet;
    }
}