using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedFood : MonoBehaviour
{
    public string name;
    private const int FOOD_SPEED = 20;

    void Update()
    {
        transform.Translate(0, 0, FOOD_SPEED * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Border")
        {
            Destroy(gameObject);
        }
    }


}
