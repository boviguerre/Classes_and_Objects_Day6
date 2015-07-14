using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Ninjas
{
    class Program
    {
        static void Main(string[] args)
        {
            //initializes a list of ninjas using user input
            List<codingNinja> ninjas = new List<codingNinja>();
            int number = 0;
            Console.WriteLine("How many ninjas are here?");
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Please enter a valid number.");
            }
            for (int i = 1; i <= number; i++)
            {
                string name;
                int level;
                if (i == 1)
                {
                    Console.WriteLine("What is the name of the first Ninja?");
                    name = Console.ReadLine();
                    Console.WriteLine("What is their current level?");
                    level = int.Parse(Console.ReadLine());
                }
                else if (i < number)
                {
                    Console.WriteLine("What is the name of the next Ninja?");
                    name = Console.ReadLine();
                    Console.WriteLine("What is their current level?");
                    level = int.Parse(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("What is the name of your last Ninja?");
                    name = Console.ReadLine();
                    Console.WriteLine("What is their current level?");
                    level = int.Parse(Console.ReadLine());
                }
                ninjas.Add(new codingNinja(level, name));
            }

            Console.WriteLine();
            Console.WriteLine();

            //asks the user if any of the ninja finished any programs
            Console.WriteLine("Did any of the ninjas complete any programs? (Y/N)");
            string response = Console.ReadLine();
            while (response != "N") //breaks loop if no ninjas complete any programs
            {
                while(response != "Y" && response != "N") //checks to make sure that Y or N was entered
                {
                    Console.WriteLine("That response isn't valid. Please enter Y or N.");
                    response = Console.ReadLine();
                }
                //identifies and holds the ninja we want to advance
                Console.WriteLine("Which ninja completed some programs?");
                string currentName = Console.ReadLine();
                codingNinja currentNinja;
                CheckNinja yesNinja = new CheckNinja(ninjas, currentName);
                while (yesNinja.CheckValues[1] == 0) //uses check ninja to validate this name
                {
                    Console.WriteLine("That ninja isn't a part of our group. Please enter a valid ninja.");
                    currentName = Console.ReadLine();
                    yesNinja = new CheckNinja(ninjas, currentName);
                }
                int numPrograms;
                currentNinja = ninjas[yesNinja.CheckValues[0]]; //holds the ninja we want to advance
                Console.WriteLine("How many programs did " + currentNinja.Name + " complete?");
                bool goodCheck = false;
                goodCheck = int.TryParse(Console.ReadLine(), out numPrograms);
                while (!goodCheck) //checks if the user inputs a number
                {
                    Console.WriteLine("Please try entering that number again.");
                    goodCheck = int.TryParse(Console.ReadLine(), out numPrograms);
                }
                Console.WriteLine("Did " + currentNinja.Name + " help anyone in finishing these programs? (Y/N)");
                string didHelp = Console.ReadLine();
                while (didHelp != "Y" && didHelp != "N") //checks if user entered Y or N
                {
                    Console.WriteLine("Sorry, I didn't catch that. Make sure to write Y or N");
                    didHelp = Console.ReadLine();
                }
                int numHelped;
                if (didHelp == "Y")
                {
                    Console.WriteLine("How many programs did they help with?");
                    numHelped = int.Parse(Console.ReadLine());
                }
                else
                {
                    numHelped = 0;
                }
                //numHelped and numPrograms hold the number of programs the ninja completed and the number of programs they helped with
                
                //advances the ninja to the desired level
                while (numPrograms > 0)
                {
                    currentNinja.setStatus(true);
                    if (numHelped > 0)
                    {
                        currentNinja.setPeerHelp(true);
                    }
                    else
                    {
                        currentNinja.setPeerHelp(false);
                    }
                    currentNinja.levelUp();
                    numHelped--;
                    numPrograms--;
                }
                Console.WriteLine("Did any other ninjas complete any programs? (Y/N)");
                response = Console.ReadLine(); // allows user to break loop
            }

            //prints out the final result of the group of ninjas
            Console.WriteLine("All of the ninjas are done with their curriculum!");
            Console.WriteLine("These are the levels they acheived:");
            foreach (codingNinja ninja in ninjas)
            {
                Console.WriteLine(ninja.Name + " got to level " + ninja.Level + " and is now considered a " + ninja.Rank);
            }
            Console.ReadLine();
        }
    }
}


