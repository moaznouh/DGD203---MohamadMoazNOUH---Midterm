// ChatGPT has been used to help write the story

using System;

namespace GameMidterm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // create the game instance and start the game
            HonerQuest honerQuest = new HonerQuest();
            honerQuest.Start();
        }
    }

    class HonerQuest
    {
        // store the player's name
        private string playerName;
        // manage valor points
        private HonorMarks honorMarks = new HonorMarks();
 

        public void Start()
        {
            // input name
            Console.WriteLine("Before you take up your sword and shield, tell us your name, brave warrior...");
            playerName = Console.ReadLine();

            // Story intro
            Console.WriteLine($"\n Amid the clash of swords and the roar of war horns, your kingdom stands on the brink of annihilation. All eyes turn to you, {playerName}, the last hope of your people");
            Console.WriteLine("You see an injured knight clutching your kingdom's banner. What do you do?");

            // question handler for asking questions
            QA qa = new QA(playerName, honorMarks);

            // 1st Q
            qa.AskQuestion(1, "\nWhat is your decision ?", "A. Help him and carry the banner forward", "B. Leave him and rush to the frontlines");

            // 2nd Q
            qa.AskQuestion(2, "\nThe enemy warlord sends a messenger offering a duel to end the battle. How do you respond",
                "A. Accept the duel and fight for your people.", "B. Refuse the duel and rally your forces for an all-out attack.");

            // 3rd Q
            qa.AskQuestion(3, "\nYou find a hidden path that could lead to the enemy's supply lines. What’s your plan?",
                "A. Take the path and sabotage the supplies.", "B. Ignore it and regroup with your forces.");

            // 4th Q
            qa.AskQuestion(4, "\nIn the chaos, you see your closest ally captured by the enemy. Will you...?",
                "A. Lead a daring rescue.", "B. Focus on the larger battle and rally your troops.");

            // result:
            Console.WriteLine($"\nWell {playerName}...");
            
            // Legendary Hero
            if (honorMarks.Mark == 4)
            {
                Console.WriteLine("\nThe Banner of Triumph:\n Your bravery and leadership have secured total victory. Songs of your deeds echo through history.");
            }

            // Strategic Victor
            else if (honorMarks.Mark == 3)
            {
                Console.WriteLine("\nThe Bloody Banner:\n You have won the war, but at great cost.Your heart bears the weight of sacrifice.");
            }

            // Narrow Survival
            else if (honorMarks.Mark >= 1 && honorMarks.Mark <=2)
            {
                
                Console.WriteLine("\nThe Broken Crown:\n The kingdom survives, but barely. Rebuilding will take generations.");
            }

            // Utter Defeat
            else
            {
             
                Console.WriteLine("The Shattered Kingdom:\n Your choices lead to defeat. The kingdom falls, and you are forced into exile.");
            }

            // exit
            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }

    class QA
    {
        private readonly string playerName;
        private readonly HonorMarks honorMarks;

        public QA(string playerName, HonorMarks honorMarks)
        {
            // player name and Honor Marks
            this.playerName = playerName;
            this.honorMarks = honorMarks;
        }

        public void AskQuestion(int questionNumber, string questionText, string option1, string option2)
        {   
            // name storage
            string answer; 

            // repeater in case of invalid input
            while (true) 
            {
                // display Q&A
                Console.WriteLine($"\n{playerName}, {questionText}");
                Console.WriteLine(option1);
                Console.WriteLine(option2);

                // answer var
                answer = Console.ReadLine();

                // answer checker
                if (answer == "A" || answer == "B")
                {
                    break;
                }

                // in case incorrect input 
                Console.WriteLine("Impossible answer, please retry answering the question WISELY !");
            }

            // update Honor Marks based on choises
            if (answer == "A")
            {
                honorMarks.Increase();
            }
                
        }
    }

    class HonorMarks
    {       
        // store the player's Valor points
        public int Mark { get; private set; } = 0; 

        public void Increase()
        {
            // increment Valor points
            Mark++;
        }
    }
}