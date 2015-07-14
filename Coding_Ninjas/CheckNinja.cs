using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Ninjas
{
    /*This class contains the methods to check if a ninja exists within the current list.
     It returns an array, where the first value holds the index of the ninja we are searching for.
     The second index contains either 0 or 1, where 1 is true, that says the the ninja exists
     within this list.*/
    class CheckNinja
    {
        int[] checkValues;

        public int[] CheckValues
        {
            get 
            {
                return this.checkValues;
            }
        }
        
        public CheckNinja(List<codingNinja> currentList, string currentNinja)
        {
            int[] values = { 0, 0 };
            for (int i = 0; i < currentList.Count; i++)
            {
                if (currentList[i].Name == currentNinja) //If the ninja exists in the list, its index is saved
                {
                    values[0] = i;
                    values[1] = 1;
                    checkValues = values;
                    break;
                }
                else //If both values in the array are 0, the ninja doesn't exist in list 
                {
                    values[0] = 0;
                    values[1] = 0;
                }
            }
            checkValues = values; //sets the array that is returned
        }
    }
}
