namespace Living
{
    public class Player
    {
        public int playerHealth = 100;
        public int healthMax = 100;
        public int playerPoints = 0;

        public int negativePoints = 10;

        public String playerName = null;
        public int playerAge = 0;
        public String playerDescription = null;
        public String playerGender = null;

        public String AboutPlayer(String name, int health, int points, int age, String description, String gender)
        {
            String playerAbout =
                $"Name: {name}\nAbout: {description}\nPoints: {points}\nHealth: {health}\nAge: {age}\nGender: {gender}";
            return playerAbout;
        }
    }

    public class Work
    {
        public static string[] initPlayer(Player pseudo_player)
        {
            string points = pseudo_player.playerPoints.ToString();
            string name = pseudo_player.playerName;

            string[] info = { points, name };
            return info;
        }

        public static float initWork(Player play)
        {
            float returningScore = 0;

            Player defaultPlayer = new Player();
            Player player = play;
            string[] recievedInfo = initPlayer(player);

            string namePlayer = recievedInfo[1];
            int scorePlayer = int.Parse(recievedInfo[0]);

            if (scorePlayer == 0)
            {
                Console.WriteLine($"\nWelcome to the work place {namePlayer}");
            }
            Console.WriteLine($"\nYour score: {scorePlayer}");
            Console.WriteLine("\nYou are a clerk here and your work is to sort the files in order\n");

            int[] files = new int[10];
            int[] sortedFiles = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            for (int i = 0; i < 9; i++)
            {
                Random random = new Random();
                int randomFileNumber;
                while (true)
                {
                    bool okay = true;
                    randomFileNumber = random.Next(1, 10);
                    foreach (int fileNumber in files)
                    {
                        if (randomFileNumber == fileNumber) { okay = false; break; }
                    }

                    if (okay)
                    {
                        files[i] = randomFileNumber;
                        break;
                    }
                }
            }
            files[9] = 0;

            string outputFiles = string.Join(", ", files);

            DateTime startTimer = DateTime.Now;
            Console.WriteLine("Sort these in under 10s\n" + outputFiles);
            string sortedFileInput = Console.ReadLine();
            DateTime endTimer = DateTime.Now;

            double totalTime = endTimer.Subtract(startTimer).TotalSeconds;
            if (totalTime > 10.2)
            {
                Console.WriteLine("Out of time, you terrible freak");
                Console.WriteLine("Your score is deducted: -" + defaultPlayer.negativePoints);
                returningScore += (float)scorePlayer - defaultPlayer.negativePoints;
            }
            else
            {
                int[] sortedFileInputArray = new int[sortedFileInput.Length];
                Console.WriteLine(string.Join("", sortedFileInputArray));
                for (int i = 0; i < 10; i++)
                {
                    int fileNumber = int.Parse("" + sortedFileInput[index: i]);
                    sortedFileInputArray[i] = fileNumber;
                }

                if (sortedFileInputArray == sortedFiles)
                {
                    Console.WriteLine("Congo");
                }
            }

            return returningScore;
        }

    }

    internal class MainClass
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            String input;

            Print("Welcome Player\n");

            Print("Your Name: ");
            input = Console.ReadLine();
            player.playerName = input;

            while (true)
            {
                Print("\nEnter Your Age: ");
                input = Console.ReadLine();
                if (Int16.Parse(input) < 13 || Int16.Parse(input) > 100)
                {
                    Print("You'll not fit here");
                    Console.ReadLine();
                    return;
                }
                else { player.playerAge = Int16.Parse(input); break; }
            }

            Print("\nTell us about yourself (a short description): ");
            input = Console.ReadLine();
            player.playerDescription = input;

            while (true)
            {
                Print("\nYour pronouns:\n1.He/Him\n2.She/Her\n3.They/Them\n(enter the option number):");
                input = Console.ReadLine();
                if (input == "1")
                {
                    player.playerGender = "He/Him";
                    break;
                }
                else if (input == "2")
                {
                    player.playerGender = "She/Her";
                    break;
                }
                else if (input == "3")
                {
                    player.playerGender = "They/Them";
                    break;
                }
                else
                {
                    Print("Choose a valid option");
                }
            }

            String informationOfPlayer = player.AboutPlayer(
                player.playerName, player.playerHealth, player.playerPoints, player.playerAge, player.playerDescription, player.playerGender
                );
            Print("");

            Print("\n" + informationOfPlayer + "\n");
            Print("Content: \n" + readContents());
            input = Console.ReadLine();

            if (input == "1")
            {
                Work.initWork(player);
            }



            Console.ReadLine();
        }

        static void Print(String arg)
        {
            Console.WriteLine(arg);
        }

        static String readContents()
        {
            String menu = "1.Work\n2.Hospital\n3.Games";
            return menu;
        }
    }
}