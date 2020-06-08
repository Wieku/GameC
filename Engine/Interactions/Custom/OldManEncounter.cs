using System.Collections.Generic;

namespace Game.Engine.Interactions.Custom
{
    class OldManEncounter: ListBoxInteraction
    {
        private static List<string> wisdoms = new List<string>
        {
            "It is better to remain silent at the risk of being thought a fool, than to talk and remove all doubt of it.",
            "The only true wisdom is in knowing you know nothing.",
            "Never laugh at live dragons.",
            "Any fool can know. The point is to understand.",
            "Let no man pull you so low as to hate him."
        };

        private FarmerEncounter farmer;
        
        internal bool hasSeeds = false;
        internal bool farmerHelped;

        private OldManMissionState missionState = OldManMissionState.NotTaken;

        private bool visited;

        private int payment;

        public OldManEncounter(FarmerEncounter farmer, GameSession ses) : base(ses)
        {
            Name = "interaction2162";
            this.farmer = farmer;
        }

        protected override void RunContent()
        {
            var greeting = visited ? "Hi again!" : "Hi adventurer!";
            
            
            switch (missionState)
            {
                    
                case OldManMissionState.NotTaken:
                    parentSession.SendText(greeting + " Welcome to my small house!");
                    parentSession.SendText("I have a little problem...");
                    parentSession.SendText("It seems that rats have eaten my carrots and I can't make the soup.");
                    parentSession.SendText("I'm sick now so I can't go find or buy fresh carrots.");
                    parentSession.SendText("Could you help me?");
                    
                    var choice = GetListBoxChoice(new List<string>() { "Sure!", "My time is not free, you know?", "I don't have time for this." });

                    switch (choice)
                    {
                        case 0:
                            payment = 30;
                            parentSession.SendText("Thanks! I need only 5 carrots! I think it's not much...");
                            
                            var choice2 = GetListBoxChoice(new List<string>() { "Of course not!", "It is..."});

                            switch (choice2)
                            {
                                case 0:
                                    parentSession.SendText("That's good! I will tell you my wisdom.");
                                    parentSession.SendText(wisdoms[Index.RNG(0, wisdoms.Count)]);
                                    break;
                                default:
                                    parentSession.SendText("Oh come on! You seem to be very strong ;)");
                                    break;
                            }
                            
                            parentSession.SendText("Bye!");
                            farmer.hasCarrotMission = true;
                            missionState = OldManMissionState.InProgress;
                            break;
                        case 1:
                            parentSession.SendText("Hmm... I'm not that rich...");
                            var award = Index.RNG(10, 20); // Less than normal for greediness
                            parentSession.SendText("Would " + award + " gold satisfy you?");
                            
                            var choice3 = GetListBoxChoice(new List<string>() { "Yeah.", "It's too low..."});

                            switch (choice3)
                            {
                                case 0:
                                    parentSession.SendText("Fine then, see you later!");
                                    missionState = OldManMissionState.InProgressGreedy;
                                    farmer.hasCarrotMission = true;
                                    payment = award;
                                    break;
                                default:
                                    parentSession.SendText("All people want these days is money... Bye.");
                                    missionState = OldManMissionState.Rejected;
                                    break;
                            }

                            break;
                        default:
                            parentSession.SendText("I understand... Bye!");
                            missionState = OldManMissionState.Rejected;
                            break;
                    }
                    
                    break;
                case OldManMissionState.InProgress:
                case OldManMissionState.InProgressGreedy:
                    parentSession.SendText(greeting + " Welcome to my small house!");
                    var carrots = parentSession.GetInventoryItemNames().FindAll(t => t == "item2165").Count;

                    if (carrots >= 5)
                    {
                        GetListBoxChoice(new List<string> { "Hi, I've collected 5 carrots"}); //Just a confirmation pause

                        if (farmerHelped)
                        {
                            parentSession.SendText("Seriously he helped you?! He's such a good man!");
                        }
                        
                        if (missionState == OldManMissionState.InProgress)
                        {
                            parentSession.SendText("Thank you! Please wait a minute...");
                            parentSession.Wait(1000);
                            parentSession.SendText("Or two. Finishing up...");
                            parentSession.Wait(1000);
                            parentSession.SendText("Here we go! Soup is ready. Please have a bowl!");
                            parentSession.Wait(1000);
                            parentSession.UpdateStat(7, 500);
                            parentSession.UpdateStat(1, 20);
                            parentSession.UpdateStat(2, 10);
                            parentSession.Wait(1000);
                            parentSession.SendText("Here's also your gold as my thanks!");
                        }
                        else
                        {
                            parentSession.UpdateStat(7, 250);
                            parentSession.SendText("Thank you! Here's your payment...");
                        }
                        
                        parentSession.UpdateStat(8, payment);
                        
                        if (hasSeeds)
                        {
                            var choice4 = GetListBoxChoice(new List<string> { "I've also have some seeds, it may help restore your plantations.", "Bye!"});

                            if (choice4 == 0)
                            {
                                parentSession.SendText("Thank you!");
                                parentSession.UpdateStat(7, 100);
                                parentSession.SendText("I don't need that many, you can sell some to the farmer.");

                                farmer.hasPartialSeeds = true;
                                parentSession.SendText("Bye!");
                                missionState = OldManMissionState.Finished;
                            }
                        }

                        parentSession.SendText("Bye!");
                        missionState = OldManMissionState.Finished;
                    } else 
                        parentSession.SendText("It's a calm day, huh?");
                    
                    break;
                case OldManMissionState.Rejected:
                    parentSession.SendText("Hi.");

                    if (hasSeeds)
                    {
                        var choice4 = GetListBoxChoice(new List<string> { "Hi, I've been passing by and I have seeds, it may help restore your plantations.", "Hi!"});

                        if (choice4 == 0)
                        {
                            parentSession.SendText("Oh God Almighty, thank you! You've restored my faith in humanity");
                            parentSession.SendText("Here, have some coins you good man.");
                            parentSession.UpdateStat(8, 10);
                            parentSession.SendText("I don't need that many, you can sell some to the farmer.");
                            farmer.hasPartialSeeds = true;
                            parentSession.SendText("Bye!");
                            missionState = OldManMissionState.Finished;
                        }
                    }
                    
                    break;
                case OldManMissionState.Finished:
                    parentSession.SendText(greeting);
                    parentSession.SendText("Do you need something?");
                    var choice5 = GetListBoxChoice(new List<string> { "Do you have any wisdom?", "I was just checking by. Bye!" });
                    switch (choice5)
                    {
                        case 0:
                            parentSession.SendText(wisdoms[Index.RNG(0, wisdoms.Count)]);
                            break;
                        default:
                            parentSession.SendText("Bye then!");
                            break;
                    }
                    break;
            }

            visited = true;
        }
    }

    enum OldManMissionState
    {
        NotTaken,
        Rejected,
        InProgress,
        InProgressGreedy,
        Finished
    }
}