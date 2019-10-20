using System;
using System.Collections.Generic;
using System.Reflection;
using ConsoleUI;
using GameEngine;
using MenuSystem;

namespace ConsoleApp
{
    class Program
    {
        private static GameSettings _gameSettings;
        private static GameStatus _gameStatus;

        static void Main(string[] args)
        {
            Console.Clear();

            _gameStatus = GameHandler.LoadGame();
            _gameSettings = ConfigHandler.LoadConfig();
//            _gameStatus = GameHandler.LoadGame();

            Console.WriteLine(_gameSettings.GameName);

            Console.WriteLine("Hello Game!");
            var menuSettings = new Menu(3)
            {
                Title = _gameSettings.GameName,
                MenuItemsDictionary = new Dictionary<string, MenuItem>()
                {
                    {
                        "S", new MenuItem()
                        {
                            Title = "Change board size" + " (current size is: " + _gameSettings.BoardHeight + "x" +
                                    _gameSettings.BoardWidth + ")",
                            CommandToExecute = SaveSettingsManually
                        }
                    },
                    {
                        "J", new MenuItem()
                        {
                            Title = "Set board size to default (4x4)",
                            CommandToExecute = SaveSettings
                        }
                    }
                }
            };
            var optionsMenu = new Menu(2)
            {
                Title = "Set up settings of Connect-4",
                MenuItemsDictionary = new Dictionary<string, MenuItem>()
                {
                    {
                        "1", new MenuItem()
                        {
                            Title = "Size",
                            CommandToExecute = null
                        }
                    },
                    {
                        "2", new MenuItem()
                        {
                            Title = "Player Names",
                            CommandToExecute = null
                        }
                    },
                    {
                        "3", new MenuItem()
                        {
                            Title = "TBD",
                            CommandToExecute = null
                        }
                    }
                }
            };


            var gameMenu = new Menu(1)
            {
                Title = $"Start a new game of {_gameSettings.GameName}",
                MenuItemsDictionary = new Dictionary<string, MenuItem>()
                {
                    {
                        "1", new MenuItem()
                        {
                            Title = "Human against Human",
                            CommandToExecute = NewGame
                        }
                    },
                    {
                        "2", new MenuItem()
                        {
                            Title = "Human against PC",
                            CommandToExecute = null
                        }
                    },
                    {
                        "3", new MenuItem()
                        {
                            Title = "Load game",
                            CommandToExecute = LoadGame
                        }
                    },
                    {
                        "4", new MenuItem()
                        {
                            Title = "Options",
                            CommandToExecute = optionsMenu.Run
                        }
                    }
                }
            };

            var menu0 = new Menu(0)
            {
                Title = _gameSettings.GameName,
                MenuItemsDictionary = new Dictionary<string, MenuItem>()
                {
                    {
                        "S", new MenuItem()
                        {
                            Title = "Start Game",
                            CommandToExecute = gameMenu.Run
                        }
                    },
                    {
                        "J", new MenuItem()
                        {
                            Title = "Set defaults for game",
                            CommandToExecute = menuSettings.Run
                        }
                    }
                }
            };

            menu0.Run();
        }

        static string LoadGame()
        {
            var loadGame = GameHandler.LoadGame();
            Game game = new Game(_gameStatus);
            game.SetBoard(loadGame.Board);
            TestGame(game);
            
            return "";
        }

        static void saveGame(Game game)
        {
            _gameStatus = new GameStatus(game.GetBoard());
            _gameStatus.Board = game.GetBoard();
            GameHandler.SaveGame(_gameStatus);
        }

        static string NewGame()
        {
            Game game = new Game(_gameSettings);
            TestGame(game);
            return "";
        }
        
        static string SaveSettings()
        {
            Console.Clear();

            var boardWidth = 4;
            var BoardHeight = 4;

            _gameSettings.BoardHeight = BoardHeight;
            _gameSettings.BoardWidth = boardWidth;

            ConfigHandler.SaveConfig(_gameSettings);

            return "a";
        }


        static string SaveSettingsManually()
        {
            Console.Clear();

            Console.WriteLine("give me board width!");
            var boardWidth = Console.ReadLine();
            Console.WriteLine("give me board height!");
            var boardHeight = Console.ReadLine();

            _gameSettings.BoardHeight = int.Parse(boardHeight);
            _gameSettings.BoardWidth = int.Parse(boardWidth);

            ConfigHandler.SaveConfig(_gameSettings);

            return "";
        }

        static string TestGame(Game gameInput)
        {
            GameLogic gameLogic = new GameLogic();

            bool isWinner = false;
            int gameStatus = 0;
            var game = gameInput;
            do
            {
                var userYint = -1;
                Console.Clear();
                if (gameStatus == game.GetBoard().Length)
                {
                    isWinner = true;
                }

                do
                {
                    if (!game._playerZeroMovesNext)
                    {
                        Console.WriteLine("player 1 turn!");
                    }
                    else
                    {
                        Console.WriteLine("player 2 turn!");
                    }

                    Console.WriteLine("Give me Y");
                    GameUi.PrintBoard(game);

                    Console.Write(">>");
                    var y = Console.ReadLine();
                    Console.Clear();


                    if (!int.TryParse(y, out userYint))
                    {
                        Console.WriteLine($" {y} is not a number. Please Choose a number!");
                        Console.WriteLine("Try again!");
                        Console.WriteLine("Give me Y");
                        GameUi.PrintBoard(game);
                        y = Console.ReadLine();
                        userYint = int.Parse(y);
                    }

                    if (int.Parse(y) > game.BoardWidth)
                    {
                        Console.WriteLine($" {y} you are trying to go out of the border!");
                        Console.WriteLine("Try again!");
                        Console.WriteLine("Give me Y");
                        GameUi.PrintBoard(game);
                        y = Console.ReadLine();
                        userYint = int.Parse(y);
                    }

                    if (game.IsColumnFull(int.Parse(y)))
                    {
                        Console.WriteLine($" {y} Column is full, choose another one!s");
                        Console.WriteLine("Try again!");
                        Console.WriteLine("Give me Y");
                        GameUi.PrintBoard(game);
                        y = Console.ReadLine();
                        userYint = int.Parse(y);
                    }
                } while (userYint < 0);


                gameStatus++;

                game.Move(userYint);
                saveGame(game);
            } while (!isWinner);

            return "GAME OVER";
        }
    }
}