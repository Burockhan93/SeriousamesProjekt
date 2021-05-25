using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitPool : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string name;
        public GameObject fruit;
        public int size;
        

    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> fruitPool;
    // Start is called before the first frame update
    void Start()
    {
        fruitPool = new Dictionary<string, Queue<GameObject>>();

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

    }

    // Update is called once per frame
    void Update()
    {

    }
}
