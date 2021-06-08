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
        
        foreach (var item in StaticClass.food)
        {
            if (item.active)
            {
                Queue<GameObject> spawnPool = new Queue<GameObject>();

                for (int i = 0; i < item.size; i++)
                {
                    GameObject fruit = Instantiate(item.food);
                    fruit.name = fruit.name.Replace("(Clone)", "").Trim();
                    fruit.SetActive(false);
                    spawnPool.Enqueue(fruit);
                    Debug.Log(fruit);
                }

                fruitPool.Add(id, spawnPool);
                id += 1;
            }
        }

        /*
        foreach (Pool pool in pools)
        {
            Queue<GameObject> spawnPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject fruit = Instantiate(pool.fruit);
                fruit.SetActive(false);
                spawnPool.Enqueue(fruit);
            }

            fruitPool.Add(pool.name, spawnPool);
        }
        */

    }

    // Update is called once per frame
    void Update()
    {

    }
}
