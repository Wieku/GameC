using System.Collections.Generic;
using Game.Engine.Items.Custom;

namespace Game.Engine.Interactions.Custom
{
    class FarmerEncounter : ListBoxInteraction
    {
        private static List<string> greetings = new List<string>
        {
            "Howdy!",
            "Hi!",
            "What a beautiful day!",
        };

        private bool hasHelpedOldMan;

        public bool HasHelpedOldMan => hasHelpedOldMan;

        internal bool hasCarrotMission;
        internal bool hasPartialSeeds;

        public FarmerEncounter(GameSession ses) : base(ses)
        {
            Name = "interaction2163";
        }

        protected override void RunContent()
        {
            parentSession.SendText(greetings[Index.RNG(0, greetings.Count)]);

            var basechoice = hasCarrotMission ? 1 : 0;

            var choices = new List<string>();

            if (hasCarrotMission)
            {
                choices.Add("I'm helping an old man. Could I buy some carrots?");
            }

            if (parentSession.currentPlayer.Gold > 10)
            {
                choices.Add("I want to buy a carrot (10 gold).");
            }

            if (parentSession.TestForItemInInventory("item2165"))
            {
                choices.Add("I want to sell a carrot.");
            }
            
            if (hasPartialSeeds)
            {
                choices.Add("Old man said you may want those seeds.");
            }
            
            choices.Add("Bye!");

            var choice = GetListBoxChoice(choices);
            
            switch (choices[choice])
            {
                case "Bye!":
                    break;
                case "I'm helping an old man. Could I buy some carrots?":
                    parentSession.SendText("Are you seriously helping him? Have some for free!");
                    parentSession.AddThisItem(new Carrot());
                    parentSession.AddThisItem(new Carrot());
                    hasHelpedOldMan = true;
                    hasCarrotMission = false;
                    break;
                case "I want to buy a carrot (10 gold).":
                    parentSession.SendText("Here you go!");
                    parentSession.AddThisItem(new Carrot());
                    parentSession.UpdateStat(8, -10);
                    break;
                case "I want to sell a carrot.":
                    parentSession.RemoveItemFromInventory("item2165");
                    parentSession.SendText("Here you go!");
                    parentSession.UpdateStat(8, 7);
                    break;
                case "Old man said you may want those seeds.":
                    parentSession.SendText("Oh my! Yield was small this year, thank you so much!!!");
                    parentSession.SendText("Have some gold!");
                    parentSession.UpdateStat(8, 15);
                    parentSession.UpdateStat(7, 50);
                    hasPartialSeeds = false;
                    break;
            }

            parentSession.SendText("Bye!");
        }
    }
}