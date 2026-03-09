public interface IBattleSystem
{
    // values relevant to both Player and NPC that is used in a battle system
    string Name { get; }
    bool IsAlive { get; }

    int AttackSpeed { get; }
    int Accuracy { get; }
    int CritChance { get; }

    double HP { get; }
    double MaxHP { get; }
    double Mana { get; }
    double MaxMana { get; }

    double BaseDamage { get; }

    bool IsCurrentlyDefending { get; }

    /// <summary>
    /// The amount of damage that either the player or NPC takes
    /// </summary>
    /// <param name="amount">damage taken</param>
    void TakeDamage(double amount);
    /// <summary>
    /// Use a healing potion, or be healed by a party member or player playing the "Healer" class
    /// </summary>
    /// <param name="amount">amount of healing done</param>
    void Heal(double amount);
    /// <summary>
    /// Spend an amount of mana on a spell or ability
    /// </summary>
    /// <param name="amount">mana spent</param>
    void SpendMana(double amount);
}