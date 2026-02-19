public interface IBattleSystem
{
    // values relevant to both Player and NPC that is used in a battle system
    string Name { get; }
    double HP { get; }
    bool IsAlive { get; }
    double BaseDamage { get; }
    /// <summary>
    /// The amount of damage that either the player or NPC takes
    /// </summary>
    /// <param name="amount">damage taken</param>
    void TakeDamage(double amount);
    /// <summary>
    /// The amount of damage dealt by either the player or an NPC
    /// </summary>
    /// <param name="rng">Random Number</param>
    /// <returns>Damage dealt</returns>
    double DealDamage(Random rng);
}