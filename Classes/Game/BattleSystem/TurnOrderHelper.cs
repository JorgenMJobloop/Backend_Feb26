public static class TurnOrderHelper
{
    public static List<IBattleSystem> BuildCombatOrder(Random rng, IEnumerable<IBattleSystem> allAlive)
    {
        return allAlive.Where(combatant => combatant.IsAlive).Select(c => new
        {
            C = c,
            Init = c.AttackSpeed + rng.Next(1, 21)
        })
        .OrderByDescending(x => x.Init)
        .Select(x => x.C)
        .ToList();
    }
}