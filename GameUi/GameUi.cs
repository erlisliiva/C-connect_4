using System;
using System.ComponentModel;
using System.Text;
using GameEngine;

namespace ConsoleUI
{
    public static class GameUi
    {
        private static readonly string _verticalSeparator = "|";
        private static readonly string _horizontalSeparator = "-";
        private static readonly string _centerSeparator = "+";

        public static void PrintBoard(Game game)
        {
            var board = game.GetBoard();

            int i;

            for (int yIndex = 0; yIndex < game.BoardHeight; yIndex++)
            {
                var line = "";


                for (int xIndex = 0; xIndex < game.BoardWidth; xIndex++)
                {
                    if (xIndex == 0)
                    {
                        line = line + _verticalSeparator;
                    }

                    line = line + GetSingleState(board[yIndex, xIndex]);


                    if (xIndex < game.BoardWidth)
                    {
                        line = line + _verticalSeparator;
                    }
                }

                Console.WriteLine(line);

                if (yIndex < game.BoardHeight)
                {
//                    int i = 0;
                    line = "";
                    for (int xIndex = 0; xIndex < game.BoardWidth; xIndex++)
                    {
                        if (xIndex == 0)
                        {
                            line += _centerSeparator;
                        }

                        if (yIndex == game.BoardHeight - 1)
                        {
                            line = line + _horizontalSeparator + (xIndex + 1) + _horizontalSeparator;
                        }
                        else
                        {
                            line = line + _horizontalSeparator + _horizontalSeparator + _horizontalSeparator;
                        }


                        if (xIndex < game.BoardWidth)
                        {
                            line = line + _centerSeparator;
                        }
                    }

                    Console.WriteLine(line);
                }
            }
        }

        public static string GetSingleState(CellState state)
        {
            switch (state)
            {
                case CellState.Empty:
                    return "   ";
                case CellState.B:
                    return " O ";
                case CellState.R:
                    return " X ";
                default:
                    throw new InvalidEnumArgumentException("Unknown enum option!");
            }
        }
    }
}