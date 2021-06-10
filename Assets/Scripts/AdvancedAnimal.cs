using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedAnimal : MonoBehaviour
{
    private Transform _player;
    private const int SPEED = 5;
    private float _step = 0;

    void Start()
    {
        //set reference to the player
        _player = FindObjectOfType<PlayerControl>().GetComponent<Transform>();

        //speed up animals in different game mode 
        if (StaticClass.gameDifficulty == 0)
        {
            _step = SPEED * 1;
        }
        else
        {
            //increase the step
            _step = SPEED * (1 + StaticClass.gameDifficulty / 5);
        }
    }


    void Update()
    {
        //move the animals towards the player
        transform.position = Vector3.MoveTowards(transform.position, _player.position, _step * Time.deltaTime);

        //keep the eyes at the player
        transform.LookAt(_player.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        //check if the animal collides with the food -> don't trigger events with the wall
        //used the Collison-Matrix
        if (other.gameObject.tag == "Food")
        {
            bool cmp = false;

            //get the food item, which is involved at the collison
            foreach (var item in StaticClass.animals)
            {
                if (item.animal.name == gameObject.name)
                {
                    //check if the food is the correct food
                    foreach (var food in item.food)
                    {
                        if (food.name == other.gameObject.name)
                        {
                            //set cmp to true to delete the animal
                            cmp = true;
                            break;
                        }
                    }
                    break;
                }
            }

            //implementation of the different game mode
            if (cmp)
            {
                this.gameObject.SetActive(false);
                StaticClass.score += 10;
            }
            else if (!cmp && StaticClass.gameDifficulty == 3)
            {
                this.gameObject.SetActive(false);
                StaticClass.score -= 5;
            }
            else if (!cmp)
            {
                other.gameObject.SetActive(false);
            }
        }

    }
}
