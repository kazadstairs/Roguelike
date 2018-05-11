using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    class MyEvent
    {
        public string DescriptionUI;
        public List<string> Options =  new List<string>();

        public virtual void Handle()
        {

            PrintUI();
            HandleUserInput();
            Options.Clear();
        }

        public void PrintUI()
        {
            Console.Clear();
            Console.WriteLine(Params.BORDER);
            //  Console.WriteLine("{0}´s turn. Round {1} out of {2}.").ActivePlayer.Name, CurrentTurn, MaxTurns);
            Program.CurrentGame.P1.PrintStats();
            Program.CurrentGame.P2.PrintStats();
            Console.WriteLine(DescriptionUI);
            foreach (string option in Options)
            {
                Console.WriteLine(option);
            }
            Console.WriteLine(Params.BORDER);
        }

        public void HandleUserInput()
        {
            if (Options.Count == 1)
            {
                Console.ReadLine();
            }
            else
            {
                int userinput = int.Parse(Console.ReadLine()); //TODO make ready for nasty users
                // find which option the user has selected:
                // add selected job to the event queue
            }
        }



    }

    class MonsterEncounterInital : MyEvent
    {

        public MonsterEncounterInital()
        {
            DescriptionUI = StoryElements.Encounters["spider"];
            
            // "You encounter a mighty spider!";
            Options.Add(StoryElements.Options["next"]);

        }
        public override void Handle()
        {
            Program.CurrentGame.EventList.Enqueue(new AfterBattle());
            base.Handle();
        }
    }

    class AfterBattle : MyEvent
    {

        public AfterBattle()
        {
            DescriptionUI = StoryElements.Options["survived"];

            Options.Add(StoryElements.Options["explore"]);
            Options.Add(StoryElements.Options["retire"]);

        }
        public override void Handle()
        {
            base.Handle();
            Console.ReadLine();
            
        }
    }





}
