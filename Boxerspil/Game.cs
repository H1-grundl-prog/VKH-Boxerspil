using System;

namespace Boxerspil
{
    public class Game
    {
        public const bool DEBUG = false;

        public bool BoxerDead => m_PlayerBoxer.Dead || m_ComputerBoxer.Dead;

        private bool m_IsRunning = true;

        private string m_PlayerName;
        private int m_Rounds;

        private string[] m_BoxerNames =
        {
            "Mike Tyson",
            "Bud Spencer",
            "Rambo",
            "RoboCop",
            "Predator"
        };

        private Boxer m_PlayerBoxer;
        private Boxer m_ComputerBoxer;

        public void Start()
        {
            // Setup the console window size to be 100 x 30 characters, and showing the start menu
            Console.SetWindowSize(Constants.WINDOW_WIDTH, Constants.WINDOW_HEIGHT);
            CLIUI.StartMenu(ref m_PlayerName, ref m_Rounds);

            // Initializing the Player object, with the new operator. 
            // And gives the player a special attack, "Nut Crusher"
            m_PlayerBoxer = new PlayerBoxer(m_PlayerName);
            m_PlayerBoxer.Attacks.Add(new Attack("Nut crusher", 6, 20));

            // Initializing the NPC object.
            string name = CLIUI.ChooseOpponentMenu(m_BoxerNames);
            m_ComputerBoxer = new NPCBoxer(name);
        }

        public void Update()
        {
            Console.Clear();

            int currentBout = 0;
            while (m_IsRunning)
            {
                while (currentBout < Constants.MAX_BOUTS)
                {
                    UpdateBout(ref currentBout);
                }
                Boxer winner = GetWinner();
                int input = CLIUI.WinnerMenu(winner);
                switch (input)
                {
                    case 1: Start(); currentBout = 0; break;
                    case 2: m_IsRunning = false; break;
                }
            }
        }

        /// <summary>
        /// Returns the winner based on how many times a boxer have won.
        /// </summary>
        /// <returns></returns>
        private Boxer GetWinner()
        {
            Boxer winner;
            if(m_PlayerBoxer.Victories > m_ComputerBoxer.Victories)
            {
                winner = m_PlayerBoxer;
            } 
            else
            {
                winner = m_ComputerBoxer;
            }
            return winner;
        }

        private void UpdateBout(ref int currentBout)
        {
            int currentRound = 0;
            bool playersTurn = new Random().Next(0, 100) >= 50;

            Console.WriteLine(new string('=', Constants.WINDOW_WIDTH));
            Console.WriteLine($"MATCH {currentBout + 1}");
            m_PlayerBoxer.Revive();
            m_ComputerBoxer.Revive();

            while (currentRound < m_Rounds && !BoxerDead)
            {
                if (playersTurn)
                {
                    m_PlayerBoxer.MakeDecision(m_ComputerBoxer);
                }
                else
                {
                    m_ComputerBoxer.MakeDecision(m_PlayerBoxer);
                }

                if (DEBUG)
                {
                    Console.WriteLine($"=== DEBUG === PlayerBoxer({m_PlayerBoxer.Name} has {m_PlayerBoxer.Health} HP) === DEBUG ===");
                    Console.WriteLine($"=== DEBUG === ComputBoxer({m_ComputerBoxer.Name} has {m_ComputerBoxer.Health} HP) === DEBUG ===");
                }

                playersTurn = !playersTurn;
                currentRound++;
            }

            Boxer winnerOfRound = m_PlayerBoxer.Dead ? m_ComputerBoxer : m_PlayerBoxer;
            winnerOfRound.Victories++;
            Console.WriteLine($"Winner of bout is {winnerOfRound.Name} ({winnerOfRound.Victories} victories)!");
            currentBout++;
        }

        public void Shutdown()
        {

        }
    }
}
