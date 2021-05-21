using System;
using System.Collections.Generic;

namespace Boxerspil
{
    public static class CLIUI
    {
        public static int WinnerMenu(Boxer winner)
        {
            Console.Clear();
            Console.WriteLine(new string('=', Constants.WINDOW_WIDTH));
            ShowWinnerTitle(winner.Name);
            Console.WriteLine();

            Console.WriteLine($"\t{winner.Name} won with {winner.Victories} victories!");
            Console.WriteLine($"\tAwesome fight!");

            Console.WriteLine();

            Console.WriteLine("\tActions:");
            Console.WriteLine("\t\t1 - CONTINUE PLAYING");
            Console.WriteLine("\t\t2 - QUIT, loser!");

            Console.WriteLine();
            Console.WriteLine(new string('=', Constants.WINDOW_WIDTH));

            string action = Console.ReadLine();
            bool result = int.TryParse(action, out int act);
            if(!result)
            {
                WinnerMenu(winner);
            }
            return act;
        }

        public static int ChooseAttackMenu(List<Attack> attacks)
        {
            Console.WriteLine(new string('=', Constants.WINDOW_WIDTH));
            Console.WriteLine("Your turn - Choose your attack!");

            int i = 0;
            foreach (Attack attack in attacks)
            {
                Console.WriteLine($"\t{i} - {attack.Name} (Damage: {attack.Damage})");
                i++;
            }

            Console.WriteLine();
            Console.WriteLine(new string('=', Constants.WINDOW_WIDTH));

            string input = Console.ReadLine();
            bool result = int.TryParse(input, out int r);
            if (!result || r >= attacks.Count)
            {
                ChooseAttackMenu(attacks);
            }

            return r;
        }

        public static string ChooseOpponentMenu(string[] opponents)
        {
            Console.Clear();
            Console.WriteLine(new string('=', Constants.WINDOW_WIDTH));
            ShowOpponentsTitle();
            Console.WriteLine();

            Console.WriteLine("\tChoose you opponent:");
            int i = 0;
            foreach(string opponent in opponents)
            {
                Console.WriteLine($"\t{i++} - {opponent}");
            }
            
            Console.WriteLine();
            Console.WriteLine(new string('=', Constants.WINDOW_WIDTH));

            int index = GetConsoleInputAsInt();
            if(index > opponents.Length)
            {
                ChooseOpponentMenu(opponents);
            }
            string name = opponents[index];
            return name;
        }

        public static void StartMenu(ref string playerName, ref int rounds)
        {
            Console.Clear();
            bool playerNameEntered = string.IsNullOrEmpty(playerName);

            Console.WriteLine(new string('=', Constants.WINDOW_WIDTH));
            ShowGameTitle();
            Console.WriteLine();

            string p = playerNameEntered ? string.Empty : playerName;
            Console.WriteLine($"\tEnter your name: {p}");
            Console.WriteLine();
            Console.WriteLine("\tHow many rounds? ");
            Console.WriteLine("\tMax 13 rounds!");
            Console.WriteLine();

            Console.WriteLine(new string('=', Constants.WINDOW_WIDTH));
            Console.WriteLine();

            Console.WriteLine("\tBoxer game made in C#");

            Console.WriteLine();
            Console.WriteLine(new string('=', Constants.WINDOW_WIDTH));

            const int HeightY = 11;
            if (playerNameEntered)
            {
                Console.SetCursorPosition("Enter your name: ".Length + 8, HeightY);
                playerName = Console.ReadLine();
            }

            Console.SetCursorPosition("How many rounds? ".Length + 8, HeightY + 2);
            string roundStr = Console.ReadLine();
            bool result = int.TryParse(roundStr, out int r);
            if (!result)
            {
                StartMenu(ref playerName, ref rounds);
            }

            if (r > Constants.MAX_ROUNDS)
            {
                StartMenu(ref playerName, ref rounds);
            }
            rounds = r;
            Console.SetCursorPosition(0, 8);
        }

        public static void ShowGameTitle()
        {
            Console.WriteLine(@"
    ______                                _ _ 
    | ___ \                              (_) |
    | |_/ / _____  _____ _ __   ___ _ __  _| |
    | ___ \/ _ \ \/ / _ \ '__| / __| '_ \| | |
    | |_/ / (_) >  <  __/ |    \__ \ |_) | | |
    \____/ \___/_/\_\___|_|    |___/ .__/|_|_|
                                   | |        
                                   |_|        ");
        }

        public static void ShowOpponentsTitle()
        {
            Console.WriteLine(@"
     _____                                    _       
    |  _  |                                  | |      
    | | | |_ __  _ __   ___  _ __   ___ _ __ | |_ ___ 
    | | | | '_ \| '_ \ / _ \| '_ \ / _ \ '_ \| __/ __|
    \ \_/ / |_) | |_) | (_) | | | |  __/ | | | |_\__ \
     \___/| .__/| .__/ \___/|_| |_|\___|_| |_|\__|___/
          | |   | |                                   
          |_|   |_|                                   ");
        }

        public static void ShowAttacksTitle()
        {
            Console.WriteLine(@"
      ___  _   _             _        
     / _ \| | | |           | |       
    / /_\ \ |_| |_ __ _  ___| | _____ 
    |  _  | __| __/ _` |/ __| |/ / __|
    | | | | |_| || (_| | (__|   <\__ \
    \_| |_/\__|\__\__,_|\___|_|\_\___/");
        }

        public static void ShowWinnerTitle(string name)
        {
            Console.WriteLine(@$"
     _    _ _                       
    | |  | (_)                      
    | |  | |_ _ __  _ __   ___ _ __ 
    | |/\| | | '_ \| '_ \ / _ \ '__|
    \  /\  / | | | | | | |  __/ |   
     \/  \/|_|_| |_|_| |_|\___|_|   
        The winner is {name}");
        }

        public static int GetConsoleInputAsInt()
        {
            string input = Console.ReadLine();
            int.TryParse(input, out int r);
            return r;
        }
    }
}
