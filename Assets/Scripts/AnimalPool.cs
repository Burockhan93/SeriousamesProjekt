using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalPool : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string name;
        public GameObject animal;
        public int size;
        
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> animalPool;
    // Start is called before the first frame update
    void Start()
    {
        animalPool = new Dictionary<string, Queue<GameObject>>();

        foreach(Pool pool in pools)
        {
            Queue<GameObject> spawnPool = new Queue<GameObject>();

            for (int i=0; i<pool.size; i++)
            {
                GameObject animal = Instantiate(pool.animal);
                animal.SetActive(false);
                spawnPool.Enqueue(animal);
            }

            animalPool.Add(pool.name, spawnPool);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
