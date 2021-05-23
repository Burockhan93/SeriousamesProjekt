using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{

    public GameObject plane;
    public GameObject player;
    public GameObject[] animalTypes;

    private float rightLimitation = 0;
    private float leftLimitation = 0;
    private float frontLimitation = 0;
    private float backLimitation = 0;
    private const int SPEED = 5;
    [SerializeField] float frequency = 3f;
    float counter = 0f;


    public static List<GameObject> animals = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        //get outer bounds to spawn animals
        Vector3 size = plane.GetComponent<Renderer>().bounds.size;
        rightLimitation = plane.transform.position.x + size[0] / 2;
        leftLimitation = plane.transform.position.x - size[0] / 2;

        frontLimitation = plane.transform.position.z + size[2] / 2;
        backLimitation = plane.transform.position.z - size[2] / 2;

        Debug.Log(rightLimitation + "; " + leftLimitation + "; " + frontLimitation + "; " + backLimitation);
    }

    // Update is called once per frame
    void Update()
    {
        this.counter = this.counter + Time.deltaTime;
        if (this.counter >= this.frequency)
        {
            this.Spawn();
        }

        // calculate distance to move
        float step = SPEED * Time.deltaTime;
        for (var i = 0; i < animals.Count; i++)
        {
            //move the animals towards the player
            animals[i].transform.position = Vector3.MoveTowards(animals[i].transform.position, player.transform.position, step);
            //keep the eyes at the player
            animals[i].transform.LookAt(player.transform.position);
        }

    }

    void Spawn()
    {
        GameObject obj;

        Vector3 spawnPosition;

        int side = Random.Range(0, 4);

        int x = Random.Range((int)leftLimitation, (int)rightLimitation);
        int y = Random.Range((int)frontLimitation, (int)backLimitation);

        switch (side)
        {
            case 0:
                spawnPosition = new Vector3(x, 0, backLimitation);
                break;
            case 1:
                spawnPosition = new Vector3(x, 0, frontLimitation);
                break;
            case 2:
                spawnPosition = new Vector3(leftLimitation, 0, y);
                break;
            default:
                spawnPosition = new Vector3(rightLimitation, 0, y);
                break;
        }

        int idx = Random.Range(0, animalTypes.Length);
        obj = Instantiate(animalTypes[idx], spawnPosition, player.transform.rotation * Quaternion.Euler(0f, 0f, 0f));
        animals.Add(obj);

        this.counter = 0f;
    }


}
