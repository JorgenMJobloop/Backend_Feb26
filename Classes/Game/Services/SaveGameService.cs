using System.Text.Json;

public static class SaveGameService
{
    private static readonly JsonSerializerOptions _options = new JsonSerializerOptions
    {
        WriteIndented = true,
        Converters = { new System.Text.Json.Serialization.JsonStringEnumConverter() }
    };

    public static string DefaultSaveFilePath()
    {
        var directory = "./SaveFiles";
        Directory.CreateDirectory(directory);
        return Path.Combine(directory, "savefile.json");
    }

    public static void Save(string path, SaveGame save)
    {
        var jsonData = JsonSerializer.Serialize(save, _options);
        // This will rewrite the file & it's content, every time this method is called!, So we can later create a "OverwriteSave" where to add data to an existing save file
        File.WriteAllText(path, jsonData);
    }
}