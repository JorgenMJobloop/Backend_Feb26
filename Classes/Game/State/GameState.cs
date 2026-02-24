public enum GameScreen
{
    MainMenu = 1,
    Town = 2,
    Explore = 3,
    Inventory = 4,
    Party = 5,
    Battle = 6,
    Exit = 7
}
public class GameState
{
    public Player Player { get; set; } = null!;
    public GameScreen Screen { get; set; } = GameScreen.MainMenu;

    public Random RNG { get; } = new Random();

    public NPC? CurrentEnemy { get; set; }

}