using System;

namespace GameEngine
{
    public class GameLogic
    {
        public bool areFourConnected(Game game)
        {
            Console.WriteLine("Start Checking if Board has a winner!");
            // horizontalCheck 
            for (int j = 0; j < game.BoardHeight - 3; j++)
            {
                for (int i = 0; i < game.BoardWidth; i++)
                {
                    if (game.GetBoard()[i, j] == CellState.B && game.GetBoard()[i, j + 1] == CellState.B &&
                        game.GetBoard()[i, j + 2] == CellState.B && game.GetBoard()[i, j + 3] == CellState.B)
                    {
                        return true;
                    }

                    if (game.GetBoard()[i, j] == CellState.R && game.GetBoard()[i, j + 1] == CellState.R &&
                        game.GetBoard()[i, j + 2] == CellState.R && game.GetBoard()[i, j + 3] == CellState.R)
                    {
                        return true;
                    }
                }
            }

            // verticalCheck
            for (int i = 0; i < game.BoardWidth - 3; i++)
            {
                for (int j = 0; j < game.BoardHeight; j++)
                {
                    if (game.GetBoard()[i, j] == CellState.B && game.GetBoard()[i + 1, j] == CellState.B &&
                        game.GetBoard()[i + 2, j] == CellState.B && game.GetBoard()[i + 3, j] == CellState.B)
                    {
                        return true;
                    }

                    if (game.GetBoard()[i, j] == CellState.R && game.GetBoard()[i + 1, j] == CellState.R &&
                        game.GetBoard()[i + 2, j] == CellState.R && game.GetBoard()[i + 3, j] == CellState.R)
                    {
                        return true;
                    }
                }
            }

            // ascendingDiagonalCheck 
            for (int i = 3; i < game.BoardWidth; i++)
            {
                for (int j = 0; j < game.BoardHeight - 3; j++)
                {
                    if (game.GetBoard()[i, j] == CellState.B && game.GetBoard()[i - 1, j + 1] == CellState.B &&
                        game.GetBoard()[i - 2, j + 2] == CellState.B && game.GetBoard()[i - 3, j + 3] == CellState.B)
                        return true;
                    if (game.GetBoard()[i, j] == CellState.R && game.GetBoard()[i - 1, j + 1] == CellState.R &&
                        game.GetBoard()[i - 2, j + 2] == CellState.R && game.GetBoard()[i - 3, j + 3] == CellState.R)
                        return true;
                }
            }

            // descendingDiagonalCheck
            for (int i = 3; i < game.BoardWidth; i++)
            {
                for (int j = 3; j < game.BoardHeight; j++)
                {
                    if (game.GetBoard()[i, j] == CellState.B && game.GetBoard()[i - 1, j - 1] == CellState.B &&
                        game.GetBoard()[i - 2, j - 2] == CellState.B && game.GetBoard()[i - 3, j - 3] == CellState.B)
                        return true;
                    if (game.GetBoard()[i, j] == CellState.R && game.GetBoard()[i - 1, j - 1] == CellState.R &&
                        game.GetBoard()[i - 2, j - 2] == CellState.R && game.GetBoard()[i - 3, j - 3] == CellState.R)
                        return true;
                }
            }

            return false;
        }
    }
}