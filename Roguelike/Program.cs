using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{

    class Program
    {
        public static Game CurrentGame;

        static void Main(string[] args)
        {
            CurrentGame = new Game();
            CurrentGame.Play();
        }
    }

    public static class Params
    {
        // Player attributes:
        public static int STARTHEALTH = 10;
        public static int STARTDMG = 1;
        public static int STARTCASH = 0;

        // Game attributes:
        public static int MAXTURNS = 10;

        // General
        public static string BORDER = "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";
    }

    class Game
    {
        public Player P1;
        public Player P2;
        Player ActivePlayer;

        public Queue<MyEvent> EventList= new Queue<MyEvent>();
        public Simulation


        Dungeon Level;

        bool finished;
        int CurrentTurn;
        int MaxTurns;


        public Game()
        {
        }

        public void Play()
        {
            P1 = new Player("Player 1");
            P2 = new Player("Player 2");

            

            finished = false;
            CurrentTurn = 0;
            MaxTurns = Params.MAXTURNS;
            SetStartPlayer();

            while (!finished && CurrentTurn < MaxTurns)
            {
                MainLoop();
            }
        }

        private void SetStartPlayer()
        {
            Console.WriteLine("PLACEHOLDER, not random yet!");

            ActivePlayer = P1;
            Console.WriteLine("Active player has been randomly set to {0}", ActivePlayer.Name);
        }

        public void MainLoop()
        {
            EventList.Enqueue(new MonsterEncounterInital());
            while (EventList.Count > 0)
            {
                EventList.Dequeue().Handle();
            }
            SwapActivePlayer();
        }
        /*
        public void PlayerAction(string[] options)
        {
            for(int i = 0; i < options.Length;i++)
            {
                Console.WriteLine("Option " + i + ": " + options[i]);
            }

            string chosenoption = Console.ReadLine();

            switch(chosenoption)
            {
                default:
                    break;

                case "0":
                    break;

            }
        }
        */
        public void PrintState()
        {
            Console.Clear();
            Console.WriteLine(Params.BORDER);
            Console.WriteLine("{0}´s turn. Round {1} out of {2}.", ActivePlayer.Name, CurrentTurn, MaxTurns);
            P1.PrintStats();
            P2.PrintStats();
            Console.WriteLine(Params.BORDER);

        }

        public void SwapActivePlayer()
        {
            if (ActivePlayer == P1)
            {
                ActivePlayer = P2;
            }
            else
            {
                ActivePlayer = P1;
                CurrentTurn++ ;
            }
        }
        
    }

    class Player
    {
        int Health;
        int Dmg;
        int Cash;
        public string Name;

        public Player(string name)
        {
            Health = Params.STARTHEALTH;
            Dmg = Params.STARTDMG;
            Cash = Params.STARTCASH;
            Name = name;
        }

        public void PrintStats()
        {
            Console.WriteLine("{0} has {1} health and {2} shiny gold coins. They deal {3} damage per hit", Name, Health, Cash, Dmg);
        }
    }

    class Dungeon
    {

    }

    class Room
    {
        //List<Reward> Rewards;
        //Enemy Greg;
        // class trap
    }

    class Enemy
    {
        public int Health;
        public int Damage;
    }

    class Reward
    {
        int Money;
        Weapon Local;
    }

    class Weapon
    {
        public int Addedbasedamage;
    }
}
