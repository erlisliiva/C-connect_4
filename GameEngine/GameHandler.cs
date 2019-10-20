using System;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace GameEngine
{
    public static class GameHandler
    {

        private const string FileName = "gameStates.json";
        
        public static void SaveGame(GameStatus gameStatus, string fileName = FileName)
        {
           
            using (var writer = System.IO.File.CreateText(fileName))
            {
                var stringJson = JsonConvert.SerializeObject(gameStatus);

                writer.Write(stringJson);
            }
        }

        public static GameStatus LoadGame(string fileName = FileName)
        {
            
            if (System.IO.File.Exists(fileName))
            {
                
                var jsonString = System.IO.File.ReadAllText(fileName);
                var stringJson = JsonConvert.DeserializeObject<GameStatus>(jsonString);
                Console.WriteLine(stringJson);

                return stringJson;
            }

            return new GameStatus();
        }
    }
}