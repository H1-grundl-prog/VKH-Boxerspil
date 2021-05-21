using System;
using System.Collections.Generic;

namespace Boxerspil
{
    public static class CLIUI
    {
        public static void WinnerMenu(Boxer winner)
        {
            Console.Clear();
            Console.WriteLine(new string('=', Constants.WINDOW_WIDTH));
            Console.WriteLine();

            Console.WriteLine("\tThe winner of the bout is...");
            Console.WriteLine($"\t{winner.Name}");

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

        public static void StartMenu(ref string playerName, ref int rounds)
        {
            Console.Clear();
            bool playerNameEntered = string.IsNullOrEmpty(playerName);

            Console.WriteLine(new string('=', Constants.WINDOW_WIDTH));
            Console.WriteLine();
            Console.WriteLine("\tH1 - Grundlæggende programmering");
            Console.WriteLine("\tBoxerspil");

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

            if (playerNameEntered)
            {
                Console.SetCursorPosition("Enter your name: ".Length + 8, 4);
                playerName = Console.ReadLine();
            }

            Console.SetCursorPosition("How many rounds? ".Length + 8, 6);
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
    }
}
