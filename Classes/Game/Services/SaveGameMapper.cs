public static class SaveGameMapper
{
    public static SaveGame MapSave(GameState state)
    {
        var player = state.Player;

        return new SaveGame
        {
            PlayerName = player.Name,
            CharacterClass = player.CharacterClass,
            HP = player.HP,
            Mana = player.Mana,
            XP = player.XP,
            Level = player.Level,
            Inventory = player.Inventory.Items.ToDictionary(key => key.Key, value => value.Value),
            Party = player.Party!.Companions.ToList()
        };
    }

    public static GameState MapLoad(SaveGame saveFile)
    {
        var player = new Player(saveFile.PlayerName, saveFile.CharacterClass!)
        {
            HP = saveFile.HP,
            Mana = saveFile.Mana,
            Level = saveFile.Level,
            XP = saveFile.XP,
        };

        player.Inventory.ClearAndSetInventory(saveFile.Inventory);
        return new GameState { Player = player };
    }
}