using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitPool : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public int id;
        public GameObject fruit;
        public int size;
    }

    public List<Pool> pools;
    public Dictionary<int, Queue<GameObject>> fruitPool;
    // Start is called before the first frame update
    void Start()
    {
        int id = 0;
        fruitPool = new Dictionary<int, Queue<GameObject>>();

        //create a fruit pool by the definition of the static class, which is defined in the game menu
        foreach (var item in StaticClass.food)
        {
            if (item.active)
            {
                //create queue
                Queue<GameObject> spawnPool = new Queue<GameObject>();

                for (int i = 0; i < item.size; i++)
                {
                    //add objects to the queue
                    GameObject fruit = Instantiate(item.food);
                    fruit.name = fruit.name.Replace("(Clone)", "").Trim();
                    fruit.SetActive(false);
                    spawnPool.Enqueue(fruit);
                }

                //add the queue to the animal pool
                fruitPool.Add(id, spawnPool);
                id += 1;
            }
        }
    }
}
