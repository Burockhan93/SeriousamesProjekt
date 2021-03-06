using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamBehaviour : MonoBehaviour
{
    public GameObject player;
    public Transform transfix;
    public Transform camOrient;//camorient ist eien transformation, die die Bewegung vom Player imitiert.

    public Vector3 cam;

    [Range(0,10)]
    public float camSpeed;

    public bool isInvert;

    void Start()
    {
        //set initial camera position
        camSpeed = 1.5f;

        cam = player.transform.position - transform.position;
        camOrient.transform.position = player.transform.position;       
        camOrient.transform.parent = null;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //move camera only if the player read the instructions
        if (!StaticClass.runGame)
        {
            return;
        }
        
        //follow the player
        camOrient.transform.position = player.transform.position;
     
        float horizontal = Input.GetAxis("Mouse X") * camSpeed;
        camOrient.transform.Rotate(0, horizontal, 0);
       

        //move the camera based on rotation
        float cam_Y_Angle = camOrient.transform.eulerAngles.y; //Euler from camorient
        float cam_X_Angle = camOrient.transform.eulerAngles.x; 

        Quaternion rotation = Quaternion.Euler(cam_X_Angle, cam_Y_Angle, 0); 
        transform.position = player.transform.position - (rotation * cam);

        // prevent to go under the map
        if (transform.position.y < player.transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y - 0.3f, transform.position.z);
        }

        //Limit camera up and down
        if (camOrient.rotation.eulerAngles.x > 53.82 && camOrient.rotation.eulerAngles.x < 180f)
        {
            camOrient.rotation = Quaternion.Euler(53.82f, 0, 0);
        }
        if (camOrient.rotation.eulerAngles.x > 180 && camOrient.rotation.eulerAngles.x < 306.18f)
        {
            camOrient.rotation = Quaternion.Euler(306.18f, 0, 0);
        }

        // Look at the player
        transform.LookAt(transfix);
    }
}
