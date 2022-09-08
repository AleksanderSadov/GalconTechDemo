namespace GalconTechDemo.Gameplay
{
    public static class AttackHelper
    {
        public static void AttackPlanet(Planet attackerPlanet, Planet defenderPlanet)
        {
            if (attackerPlanet != null && defenderPlanet != null)
            {
                AttackPlanetEvent attackPlanetEvent = Events.AttackPlanetEvent;
                attackPlanetEvent.attackerPlanet = attackerPlanet;
                attackPlanetEvent.defenderPlanet = defenderPlanet;
                EventsManager.Broadcast(attackPlanetEvent);
            }
        }
    }
}

