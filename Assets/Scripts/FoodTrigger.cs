using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodTrigger : MonoBehaviour
{
    private const int FOOD_SPEED = 20;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        transform.Translate(0, 0, FOOD_SPEED * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collison " + gameObject.name + " with " + collision.collider.gameObject.name + " Tag " + collision.collider.gameObject.tag);

        if (checkFood(gameObject.name, collision.gameObject.name))
        {
            AnimalSpawner.animals.Remove(collision.collider.gameObject);
            Destroy(collision.collider.gameObject);

            //add points to score
            StaticClass.score += 10;
        }

        Destroy(gameObject);
    }

    bool checkFood(string food, string animal)
    {
        if (food == "Food_Banana_01(Clone)")
        {
            switch (animal)
            {
                case "Animal_Cow_White(Clone)":
                    return true;
                case "Animal_Cow_Brown(Clone)":
                    return true;
                default:
                    return false;
            }
        }

        if (food == "Food_Bone_01(Clone)")
        {
            switch (animal)
            {
                case "Dog_Beagle_01(Clone)":
                    return true;
                case "Dog_BorderCollie_01(Clone)":
                    return true;
                case "Dog_BullDog_01(Clone)":
                    return true;
                case "Dog_BullTerrier_01(Clone)":
                    return true;
                case "Dog_Doberman_01(Clone)":
                    return true;
                case "Dog_GermanShepherd_01(Clone)":
                    return true;
                case "Dog_Labrador_01(Clone)":
                    return true;
                case "Dog__01(Clone)":
                    return true;
                case "Pug(Clone)":
                    return true;
                case "Dog_RhodesianRidgeback_01(Clone)":
                    return true;
                case "Dog_SaintBernard_01(Clone)":
                    return true;
                case "Animal_Fox_01(Clone)":
                    return true;
                case "Animal_Fox_02(Clone)":
                    return true;
                default:
                    return false;
            }
        }

        if (food == "Food_Cookie_01(Clone)")
        {
            switch (animal)
            {
                case "":
                    return true;
                default:
                    return false;
            }
        }

        if (food == "Food_EnergyCan_01(Clone)")
        {
            switch (animal)
            {
                case "":
                    return true;
                default:
                    return false;
            }
        }

        if (food == "Food_Fish_Cooked(Clone)")
        {
            switch (animal)
            {
                case "Dog_Beagle_01(Clone)":
                    return true;
                case "Dog_BorderCollie_01(Clone)":
                    return true;
                case "Dog_BullDog_01(Clone)":
                    return true;
                case "Dog_BullTerrier_01(Clone)":
                    return true;
                case "Dog_Doberman_01(Clone)":
                    return true;
                case "Dog_GermanShepherd_01(Clone)":
                    return true;
                case "Dog_Labrador_01(Clone)":
                    return true;
                case "Dog__01(Clone)":
                    return true;
                case "Pug(Clone)":
                    return true;
                case "Dog_RhodesianRidgeback_01(Clone)":
                    return true;
                case "Dog_SaintBernard_01(Clone)":
                    return true;
                case "Animal_Fox_01(Clone)":
                    return true;
                case "Animal_Fox_02(Clone)":
                    return true;
                default:
                    return false;
            }
        }

        if (food == "Food_Organic_Apple_01(Clone)" || food == "Food_Organic_Apple_03(Clone)")
        {
            switch (animal)
            {
                case "Animal_Horse_Black(Clone)":
                    return true;
                case "Animal_Horse_Brown(Clone)":
                    return true;
                default:
                    return false;
            }
        }

        if (food == "Food_Organic_Carrot(Clone)")
        {
            switch (animal)
            {
                case "Animal_Horse_Black(Clone)":
                    return true;
                case "Animal_Horse_Brown(Clone)":
                    return true;
                default:
                    return false;
            }
        }

        if (food == "Food_Organic_Pear_02(Clone)")
        {
            switch (animal)
            {
                case "":
                    return true;
                default:
                    return false;
            }
        }
        if (food == "Food_Pizza_01(Clone)")
        {
            switch (animal)
            {
                case "":
                    return true;
                default:
                    return false;
            }
        }
        if (food == "Food_Sandwich_01(Clone)")
        {
            switch (animal)
            {
                case "":
                    return true;
                default:
                    return false;
            }
        }
        if (food == "Food_Steak_01(Clone)")
        {
            switch (animal)
            {
                case "":
                    return true;
                default:
                    return false;
            }
        }
        if (food == "Food_Wine_01(Clone)")
        {
            switch (animal)
            {
                case "":
                    return true;
                default:
                    return false;
            }
        }

        return false;

    }

}
