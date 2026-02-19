public class Player
{
    /// <summary>
    /// Hitpoints property
    /// </summary>
    public double HP { get; private set; }
    /// <summary>
    /// Mana property
    /// </summary>
    public double Mana { get; private set; }
    /// <summary>
    /// List collection for the Stats field
    /// </summary>
    public List<string>? Stats = new List<string>();
    /// <summary>
    /// Character class (mage, warrior, ranger)
    /// </summary>
    public CharacterClass? CharacterClass { get; set; }
    private double BaseDamage = 30;
    private NPC npc = new NPC();

    /// <summary>
    /// Constructor that allows for "empty" initalization when an object is created to referance this class
    /// </summary>
    public Player()
    {

    }

    /// <summary>
    /// Constructor that takes in values and passes them along to the object
    /// </summary>
    /// <param name="hp">Hitpoints</param>
    /// <param name="mana">Mana</param>
    /// <param name="stats">Overall stats</param>
    /// <param name="character">type of char class</param>
    public Player(double hp, double mana, List<string> stats, CharacterClass character)
    {
        HP = hp;
        Mana = mana;
        Stats = stats;
        CharacterClass = character;
    }

    public void Attack(CharacterClass character)
    {
        var weapon = character.Weapon;
        var rng = new Random().Next(10);
        var npcHP = npc.HP = 30;
        var experience = npc.XPWhenDefeated * character.XPMultiplier;
        while (HP >= 100)
        {
            // get the character class
            if (character.Build == "Warrior" || character.Build == "Ranger")
            {
                var dmg = GetDamage(rng);
                if (dmg == 1)
                {
                    npcHP -= 17.5;
                    Console.WriteLine("Landed a critical hit");

                }
                else
                {
                    Console.WriteLine($"{character.Build} did {dmg} damage!");
                    Console.WriteLine($"{character.Weapon} did {dmg} damage to {npc.TypeOfFoe} and gained {experience} experience from defeating it!");
                }
            }
            else
            {

            }
            HP--;
            if (HP == 0)
            {
                break;
            }
        }
    }

    /// <summary>
    /// Get the current damage dealt if the attack is successful
    /// </summary>
    /// <param name="roll">Use a Random Number Generator to get a accuracy roll</param>
    /// <returns>Damage dealt</returns>
    private double GetDamage(double roll)
    {
        return BaseDamage / roll * 100;
    }
}