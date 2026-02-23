public class BattleEngine
{
    /// <summary>
    /// Private Random Number Generator class instance field
    /// </summary>
    private readonly Random _rng = new Random();

    /// <summary>
    /// simulate battles
    /// </summary>
    /// <param name="player">The player</param>
    /// <param name="npc">npc</param>
    public void Fight(Player player, NPC npc)
    {
        Console.WriteLine($"Battle started: {player.Name} VS {npc.Name}");

        // number of rounds
        int rounds = 1;

        while (player.IsAlive && npc.IsAlive)
        {
            Console.WriteLine($"-- Round: {rounds} --");
            UseAttack(player, npc);

            // Check if the NPC is defeated
            if (!npc.IsAlive)
            {
                break;
            }

            // Check if the player is defeated
            UseAttack(npc, player);
            Console.WriteLine($"{player.Name} HP: {player.HP} | {npc.Name} HP: {npc.HP}");
            rounds++;
        }

        if (player.IsAlive)
        {
            Console.WriteLine($"{player.Name} defeated {npc.Name}\nand gained {npc.XPWhenDefeated} experience.");

            // implementing the looting system
            var loot = npc.RollLoot(_rng, rolls: 1, dropChance: 0.85);

            if (loot.Count == 0)
            {
                Console.WriteLine($"{npc.Name} dropped no items");
            }
            else
            {
                foreach (var (item, amount) in loot)
                {
                    player.Inventory.Add(item, amount);
                    Console.WriteLine($"Items looted: {item} : {amount}");
                }
            }
            Console.WriteLine($"Items currently in inventory: {player.Inventory}");
        }
        else
        {
            Console.WriteLine($"{player.Name} was defeated by {npc.Name}...");
        }
    }

    /// <summary>
    /// A helper method for performing attacks within the battle engine
    /// </summary>
    /// <param name="attacker">attacker</param>
    /// <param name="defender">defender</param>
    private void UseAttack(IBattleSystem attacker, IBattleSystem defender)
    {
        double damage = attacker.DealDamage(_rng);

        if (damage == 0)
        {
            Console.WriteLine($"{attacker.Name} missed their attack! And {defender.Name} took {damage} damage!");
            return;
        }

        defender.TakeDamage(damage);
        Console.WriteLine($"{attacker.Name} hit {defender.Name} for {damage} damage!");
    }
}