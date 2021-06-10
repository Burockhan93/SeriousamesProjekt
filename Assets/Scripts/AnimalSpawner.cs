using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{

    public GameObject plane;
    public GameObject player;
    public GameObject[] animalTypes;
    public AnimalPool animalPool;

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
        //get outer bounds to spawn animals outside the game plane
        Vector3 size = plane.GetComponent<Renderer>().bounds.size;
        rightLimitation = plane.transform.position.x + size[0] / 2;
        leftLimitation = plane.transform.position.x - size[0] / 2;

        frontLimitation = plane.transform.position.z + size[2] / 2;
        backLimitation = plane.transform.position.z - size[2] / 2;
    }

    // Update is called once per frame
    void Update()
    {
        //check if the user read the instructions
        if (!StaticClass.runGame)
        {
            return;
        }

        //increase spawn rate until max freqency of 2 animals per second
        if (this.frequency > 0.5f)
        {
            this.frequency -= Time.deltaTime * 0.05f;
        }

        //increase the counter to spawn animals
        this.counter = this.counter + Time.deltaTime;
        if (this.counter >= this.frequency)
        {
            this.Spawn();
        }

    }

    void Spawn()
    {
        Vector3 spawnPos = spawnPoint();
        GameObject animal = spawnAnimal();

        if (animal == null) return;
        animal.SetActive(true);
        animal.transform.position = spawnPos;
        animal.transform.rotation = Quaternion.identity;

        this.counter = 0;
    }

    GameObject spawnAnimal()
    {
        GameObject animal;
        int idx = Random.Range(0, animalPool.animalPool.Count);

        animal = animalPool.animalPool[idx].Dequeue();
        animalPool.animalPool[idx].Enqueue(animal);

        return animal != null ? animal : null;
    }

    Vector3 spawnPoint()
    {
        //choose random point outside the game field to spawn the animals
        int side = Random.Range(0, 4);
        Vector3 spawnPosition;

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

        return spawnPosition;
    }

}
