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

        //increase spawn rate until max freqency of 2 animals per second
        if (this.frequency > 0.5f)
        {
            this.frequency -= Time.deltaTime * 0.05f;
        }

        this.counter = this.counter + Time.deltaTime;
        if (this.counter >= this.frequency)
        {
            this.Spawn();
        }

        //// calculate distance to move and bring it into the dependency of the selected game difficulty
        //float step = 0;
        //switch (StaticClass.gameDifficulty)
        //{
        //    case 1:
        //        step = SPEED * Time.deltaTime * 1.5f;
        //        break;
        //    default:
        //        step = SPEED * Time.deltaTime;
        //        break;
        //}

        //for (var i = 0; i < animals.Count; i++)
        //{
        //    //move the animals towards the player
        //    animals[i].transform.position = Vector3.MoveTowards(animals[i].transform.position, player.transform.position, step);
        //    //keep the eyes at the player
        //    animals[i].transform.LookAt(player.transform.position);
        //}

    }

    void Spawn()
    {
        Vector3 spawnPos = spawnPoint();
        GameObject animal = spawnAnimal();

        animal.SetActive(true);
        animal.transform.position = spawnPos;
        animal.transform.rotation = Quaternion.identity;
       // animalPool.animalPool["chicken"].Enqueue(animal);

        this.counter = 0;

        //GameObject animal = Instantiate(animalTypes[idx], spawnPos, player.transform.rotation * Quaternion.Euler(0f, 0f, 0f));

        //animals.Add(obj);

        //this.counter = 0f;
    }

    GameObject spawnAnimal()
    {
        GameObject animal;
        int idx = Random.Range(0, animalPool.pools.Count);

        switch (idx)
        {
            case 0: animal = animalPool.animalPool["chicken"].Dequeue();
                animalPool.animalPool["chicken"].Enqueue(animal);
                return animal;
                break;
            case 1:
                animal = animalPool.animalPool["chicken_brown"].Dequeue();
                animalPool.animalPool["chicken_brown"].Enqueue(animal);
                return animal;
                break;
            case 2:
                animal = animalPool.animalPool["chicken_white"].Dequeue();
                animalPool.animalPool["chicken_white"].Enqueue(animal);
                return animal;
                break;
            case 3:
                animal = animalPool.animalPool["cow_brown"].Dequeue();
                animalPool.animalPool["cow_brown"].Enqueue(animal);
                return animal;
                break;
            case 4:
                animal = animalPool.animalPool["cow_white"].Dequeue();
                animalPool.animalPool["cow_white"].Enqueue(animal);
                return animal;
                break;
            case 5:
                animal = animalPool.animalPool["horse_black"].Dequeue();
                animalPool.animalPool["horse_black"].Enqueue(animal);
                return animal;
                break;
            case 6:
                animal = animalPool.animalPool["horse_brown"].Dequeue();
                animalPool.animalPool["horse_brown"].Enqueue(animal);
                return animal;
                break;
            case 7:
                animal = animalPool.animalPool["rooster"].Dequeue();
                animalPool.animalPool["rooster"].Enqueue(animal);
                return animal;
                break;
            case 8:
                animal = animalPool.animalPool["beagle"].Dequeue();
                animalPool.animalPool["beagle"].Enqueue(animal);
                return animal;
                break;
            case 9:
                animal = animalPool.animalPool["shepherd"].Dequeue();
                animalPool.animalPool["shepherd"].Enqueue(animal);
                return animal;
                break;
            default:
                break;
        }

        return null;
    }

    Vector3 spawnPoint()
    {
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
