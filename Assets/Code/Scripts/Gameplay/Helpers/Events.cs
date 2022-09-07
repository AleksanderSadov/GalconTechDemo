namespace GalconTechDemo.Gameplay
{
    public static class Events
    {
        public static GameStartedEvent OnGameStartedEvent = new GameStartedEvent();
        public static PlanetsGeneratedEvent PlanetsGeneratedEvent = new PlanetsGeneratedEvent();
        public static PlanetClickedEvent PlanetSelectedEvent = new PlanetClickedEvent();
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

    public class PlaneClickedEvent : GameEvent { }

    public class AttackPlanetEvent : GameEvent
    {
        public Planet attackerPlanet;
        public Planet defenderPlanet;
    }
}