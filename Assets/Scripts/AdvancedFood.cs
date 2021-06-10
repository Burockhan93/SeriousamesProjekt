using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedFood : MonoBehaviour
{
    private const int FOOD_SPEED = 20;

    void Update()
    {
        //move the food
        transform.Translate(0, 0, FOOD_SPEED * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {   
        //delete the food, if it collides with the border or an animal
        if (other.gameObject.tag == "Border" || other.gameObject.tag == "Animal")
        {
            gameObject.SetActive(false);
        }
        
    }


}
