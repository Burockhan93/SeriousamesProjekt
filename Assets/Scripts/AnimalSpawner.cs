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
            animals[i].transform.position = Vector3.MoveTowards(animals[i].transform.position, player.transform.position, step);
            // Console.WriteLine("Amount is {0} and type is {1}", myMoney[i].amount, myMoney[i].type);
        }

    }

    void Spawn()
    {
        GameObject obj;

        Vector3 spawnPosition = new Vector3(5, 0, 5);
        //TODO - get vector to the player
        int idx = Random.Range(0, animalTypes.Length);
        obj = Instantiate(animalTypes[idx], spawnPosition, player.transform.rotation * Quaternion.Euler(0f, 0f, 0f));

        // var rBody = obj.GetComponent<Rigidbody>();
        // rBody.AddForce(player.transform.forward * SPEED);

        animals.Add(obj);

        // rBody.useGravity = false;
        // var bCol = obj.AddComponent<BoxCollider>();


        // // bCol.bounds = obj.GetComponent<Renderer>().bounds;
        // var meshFilter = obj.AddComponent<MeshFilter>();


        // var renderer2 = obj.AddComponent<MeshRenderer>();
        // MeshRenderer renderer = obj.GetComponent<MeshRenderer>();
        // bCol.center = renderer.bounds.center;
        // bCol.size = renderer.bounds.size;

        // Debug.Log(bCol.center);
        // Debug.Log(bCol.size);

        // // bCol.attachedRigidbody = rBody;
        // bCol.isTrigger = true;
        this.counter = 0f;
    }


}
