using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedAnimal : MonoBehaviour
{
    private Transform _player;
    private const int SPEED = 5;
    private float _step = 0;
    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<PlayerControl>().GetComponent<Transform>();

        if (StaticClass.gameDifficulty == 0)//Initialization dirctly from Game Scene
        {
            _step = SPEED * 1;
        }
        else
        {
            _step = SPEED * StaticClass.gameDifficulty/2;
        }
    }

    // Update is called once per frame
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
            //foodName = other.GetComponent<AdvancedFood>().name;
            // eine Method von einer statischen neuen Klasse, welche daf�r sorgt, ob das Essen zum Tier passt
            //bool cmp = FoodAnimalComparison.compare(this.name, foodName);
            //check if the food is tagged inside the animal body
            bool cmp = false;
            Debug.Log(gameObject);
            Debug.Log(other.gameObject);

            foreach (var item in StaticClass.animals)
            {
                // Debug.Log(item.animal.name + " " + gameObject.name);
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

            // if(StaticClass.animals.Get(this).Contains(other)){
            //     cmp = true;
            // } 

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
