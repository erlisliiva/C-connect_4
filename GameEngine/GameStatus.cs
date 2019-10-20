using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GameEngine
{
    public class GameStatus
    {
        

        public CellState[,] Board { get; set; }
        public int BoardHeight { get; set; } = 0;
        public int BoardWidth { get; set; } = 0;

        public GameStatus(CellState[,] board)
        {
            BoardWidth = board.GetLength(1);
            BoardHeight = board.GetLength(0);
        }

        public GameStatus()
        {
            
        }

        
    }
    
}