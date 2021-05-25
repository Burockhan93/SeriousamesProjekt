using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodAnimalComparison : MonoBehaviour
{
   public static bool compare(string nameAnimal, string nameFood)
    {
        if ((nameAnimal == "chick") || (nameAnimal == "chicken") || (nameAnimal == "cow") ||
            (nameAnimal == "rooster") || (nameAnimal == "horse")) {

            if ((nameFood == "banana") || (nameFood == "apple") || (nameFood == "carrot") || (nameFood == "pear"))
            {
                return true;
            }
            else
            {
                return false;
            }

        } else if ((nameAnimal == "beagle") || (nameAnimal == "shepherd")) {

            if ((nameFood == "bone") || (nameFood == "steak") || (nameFood == "cookie"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else { return false; }
    }
}
