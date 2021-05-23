using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObjects : MonoBehaviour
{
    public GameObject player;

    public GameObject foodBanana;
    public GameObject foodBone;
    public GameObject foodCookie;


    private const int DESTROY_AFTER = 3;
    private const int SPEED = 200;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Debug.Log("Pressed primary button.");
            ThrowObject();
        }
    }

    public void ThrowObject()
    {
        GameObject obj;
        switch (Random.Range(0, 3))
        {
            case 0:
                obj = Instantiate(foodBanana, new Vector3(player.transform.position.x, 1.5f, player.transform.position.z), player.transform.rotation * Quaternion.Euler(0f, 0f, 0f));
                break;
            case 1:
                obj = Instantiate(foodBone, new Vector3(player.transform.position.x, 1.5f, player.transform.position.z), player.transform.rotation * Quaternion.Euler(0f, 0f, 0f));
                break;
            default:
                obj = Instantiate(foodCookie, new Vector3(player.transform.position.x, 1.5f, player.transform.position.z), player.transform.rotation * Quaternion.Euler(0f, 0f, 0f));
                break;
        }
        //add force to throw the object
        obj.GetComponent<Rigidbody>().AddForce(player.transform.forward * SPEED);
        var bCol = obj.AddComponent<BoxCollider>();
        bCol.isTrigger = true;

        Destroy(obj, DESTROY_AFTER);
    }


    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collison - TO");
        Destroy(collision.collider.gameObject);
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider collision){
        Debug.Log("Trigger - TO");
        Destroy(collision.GetComponent<Collider>().gameObject);
        Destroy(gameObject);
    }

}
