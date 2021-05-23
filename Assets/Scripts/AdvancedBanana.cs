using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedBanana : MonoBehaviour
{
         private const int FOOD_SPEED = 20;
    void Update()
    {
        transform.Translate(0, 0, FOOD_SPEED * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collison - TO");
        // Destroy(collision.collider.gameObject);
        Destroy(gameObject);
    }

}
