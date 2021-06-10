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
        _player = FindObjectOfType<PlayerControl>().GetComponent<Transform>();

        if (StaticClass.gameDifficulty == 0)
        {
            _step = SPEED * 1;
        }
        else
        {
            _step = SPEED * StaticClass.gameDifficulty/2;
        }
    }

    
    void Update()
    {
        //move the animals towards the player
        transform.position = Vector3.MoveTowards(transform.position, _player.position, _step*Time.deltaTime);
        
        //keep the eyes at the player
        transform.LookAt(_player.position);
    }

    private void OnTriggerEnter(Collider other) 
    {
        string foodName = "";
        if (other.gameObject.tag == "Food")
        {
            Debug.Log("Food found");
            bool cmp = false;

            foreach (var item in StaticClass.animals)
            {
                
                if(item.animal.name == gameObject.name){
                    Debug.Log("Found animal");
                    foreach (var food in item.food)
                    {
                        if(food.name == other.gameObject.name){
                            Debug.Log("Hit correct food");
                            cmp = true;
                            break;
                        }
                    }
                    break;
                }
            }

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
