using System.Text.Json;

namespace GameEngine
{
    public static class ConfigHandler
    {

        private const string FileName = "gameSettings.json";
        
        public static void SaveConfig(GameSettings gameSettings, string fileName = FileName)
        {
            var jsonOptions = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            
            using (var writer = System.IO.File.CreateText(fileName))
            {
                var jsonString = JsonSerializer.Serialize(gameSettings, jsonOptions);
                writer.Write(jsonString);
            }
        }

        public static GameSettings LoadConfig(string fileName = FileName)
        {
            
            if (System.IO.File.Exists(fileName))
            {
                var jsonString = System.IO.File.ReadAllText(fileName);
                var res = JsonSerializer.Deserialize<GameSettings>(jsonString);

                return res;
            }

            return new GameSettings();
        }
    }
}