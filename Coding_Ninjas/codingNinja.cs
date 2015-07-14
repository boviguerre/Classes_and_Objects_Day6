using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Ninjas
{
    class codingNinja
    {
        //Initialize values that will be held by each ninja object
        int level;
        bool projectStatus = false;
        bool peerHelp = false;
        string rank = "Beginner";
        string name;

        //allows level to be accessed
        public int Level
        {
            get 
            { 
                return this.level; 
            }
        }

        //allows name to be accessed
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        //allows rank to be accessed
        public string Rank
        {
            get
            {
                return this.rank;
            }
        }

        //changes the project status of the ninja object
        public void setStatus(bool status)
        {
            projectStatus = status;
        }

        //changes the peerHelp status of the ninja object
        public void setPeerHelp(bool help)
        {
            peerHelp = help;
        }

        //constructor for the ninja object
        public codingNinja(int currentLevel, string newName)
        {
            level = currentLevel;
            projectStatus = false;
            peerHelp = false;
            name = newName;
            this.currentRank();
        }

        //advances the ninja by the correct number of levels (either one or two)
        public void levelUp()
        {
            if (this.projectStatus)
            {
                this.level++;
                if (this.peerHelp)
                    this.level++;
            }
            this.currentRank();
        }

        //updates the rank of the ninja
        private void currentRank()
        {
            if (this.level < 5)
            {
                rank = "Beginner";
            }
            else if (this.level < 10)
            {
                rank = "Grasshopper";
            }
            else if (this.level < 15)
            {
                rank = "Journeyman";
            }
            else if (this.level < 20)
            {
                rank = "Rock Star";
            }
            else if (this.level < 25)
            {
                rank = "Ninja";
            }
            else
            {
                rank = "Jedi";
            }
        }
    }
}
