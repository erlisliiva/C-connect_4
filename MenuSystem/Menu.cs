using System;
using System.Collections.Generic;

namespace MenuSystem
{
    public class Menu
    {
        private int _menuLevel;
        private const string MenuCommandExit = "X";
        private const string MenuCommandMainMenu = "M";
        private const string MenuCommandReturnToPrevious = "P";
        public string Title { get; set; }

        private Dictionary<string, MenuItem> _menuItemsDictionary = new Dictionary<string, MenuItem>();

        public Menu(int menuLevel = 0)
        {
            _menuLevel = menuLevel;
        }


        public Dictionary<string, MenuItem> MenuItemsDictionary
        {
            get => _menuItemsDictionary;
            set
            {
                _menuItemsDictionary = value;
                if (_menuLevel >= 1)
                {
                    _menuItemsDictionary.Add(MenuCommandMainMenu,
                        new MenuItem() {Title = "Return to Main Menu"});
                }

                if (_menuLevel >= 2)
                {
                    _menuItemsDictionary.Add(MenuCommandReturnToPrevious,
                        new MenuItem() {Title = "Return to Previous Menu"});
                }

                _menuItemsDictionary.Add(MenuCommandExit,
                    new MenuItem() {Title = "Exit"});
            }
        }

        public string Run()
        {
            var command = "";
            do
            {
                Console.WriteLine(Title);
                Console.WriteLine("===================================");

                foreach (var menuItem in MenuItemsDictionary)
                {
                    Console.Write(menuItem.Key);
                    Console.Write(" ");
                    Console.WriteLine(menuItem.Value);
                }

                Console.WriteLine("----------");
                Console.Write(">");
                command = Console.ReadLine()?.Trim().ToUpper() ?? "";

                var returnCommand = "";
                if (MenuItemsDictionary.ContainsKey(command))
                {
                    if (MenuItemsDictionary[command].CommandToExecute != null)
                    {
                        returnCommand = MenuItemsDictionary[command].CommandToExecute(); // run the command 
                        break;
                    }
                }

              
                if (returnCommand == MenuCommandExit)
                {
                    command = MenuCommandExit;
                }

                if (returnCommand == MenuCommandMainMenu)
                {
                    if (_menuLevel != 0)
                    {
                        command = MenuCommandMainMenu;
                    }
                }
            } while (command != MenuCommandExit &&
                     command != MenuCommandMainMenu &&
                     command != MenuCommandReturnToPrevious);
            return command;
        }
    }
}