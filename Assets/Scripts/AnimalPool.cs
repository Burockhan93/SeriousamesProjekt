using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalPool : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public int id;
        public GameObject animal;
        public int size;
    }

    public List<Pool> pools;
    public Dictionary<int, Queue<GameObject>> animalPool;
    // Start is called before the first frame update
    void Start()
    {
        int id = 0;
        animalPool = new Dictionary<int, Queue<GameObject>>();

        //create an animal pool by the definition of the static class, which is defined in the game menu
        foreach (var item in StaticClass.animals)
        {
            if (item.active)
            {
                //create queue
                Queue<GameObject> spawnPool = new Queue<GameObject>();

                for (int i = 0; i < item.size; i++)
                {
                    //add objects to the queue
                    GameObject animal = Instantiate(item.animal);
                    animal.name = animal.name.Replace("(Clone)", "").Trim();
                    animal.SetActive(false);
                    spawnPool.Enqueue(animal);
                }

                //add the queue to the animal pool
                animalPool.Add(id, spawnPool);
                id += 1;
            }
        }
    }
}
