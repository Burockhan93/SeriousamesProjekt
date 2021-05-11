using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedBanana : MonoBehaviour
{
 
    void Update()
    {
        transform.Translate(0, 0, 100*Time.deltaTime);
    }
}
