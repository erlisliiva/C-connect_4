using System;

namespace GameEngine
{
    /// <summary>
    /// Connect-4
    /// </summary>
    public class Game
    {
        // null, X, O
        private CellState[,] Board { get; set; }
        public int BoardHeight { get; }
        public int BoardWidth { get; }

        public bool _playerZeroMovesNext;


        public Game(GameSettings settings)
        {
            int boardHeight = settings.BoardHeight;
            int boardWidth = settings.BoardWidth;
            
            if (settings.BoardHeight < 4 || settings.BoardWidth < 4)
            {
                throw new ArgumentException("Choose a different size, bigger than 3x3!");
            }

            BoardHeight = settings.BoardHeight;
            BoardWidth = settings.BoardWidth;
            Board = new CellState[boardHeight, boardWidth];
        }

        public Game(GameStatus gameStatus)
        {
            int boardHeight = gameStatus.BoardHeight;
            int boardWidth = gameStatus.BoardWidth;
            
            if (gameStatus.BoardHeight < 4 || gameStatus.BoardWidth < 4)
            {
                throw new ArgumentException("Choose a different size, bigger than 3x3!");
            }

            BoardHeight = gameStatus.BoardHeight;
            BoardWidth = gameStatus.BoardWidth;
            Board = new CellState[boardHeight, boardWidth];
        }

        public void SetBoard(CellState [,] cs)
        {
            this.Board = cs;
        }

       
        public CellState[,] GetBoard()
        {
            var result = new CellState[BoardHeight, BoardWidth];
            Array.Copy(Board, result, Board.Length);
            return result;
        }

        public void Move(int y)
        {
            for (int i = BoardHeight - 1; i >= 0; i--)
            {
                if (Board[i, y - 1] == CellState.Empty)
                {
                    Board[i, y - 1] = _playerZeroMovesNext ? CellState.B : CellState.R;

                    break;
                }
            }

            _playerZeroMovesNext = !_playerZeroMovesNext;
        }

        public bool IsColumnFull(int y)
        {
            return Board[0, y - 1] != CellState.Empty;
        }
    }
}