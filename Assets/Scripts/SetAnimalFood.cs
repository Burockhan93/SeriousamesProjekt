using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetAnimalFood : MonoBehaviour
{
    public static List<bool> animals = new List<bool>();
    public static List<bool> foods = new List<bool>();

    [SerializeField] private List<Toggle> animaltoggles;
    [SerializeField] private List<Toggle> foodtoggles;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
    }

    public void SetAnimFood()
    {
        /*
        for (int i = 0; i < animaltoggles.Count; i++)
        {
            if (animaltoggles[i].isOn) {
                animals.Add(true);
            }
            else
            {
                animals.Add(false);
            }
            
        }
        for (int i = 0; i < foodtoggles.Count; i++)
        {
            if (foodtoggles[i].isOn) {
                foods.Add(true);
            }
            else
            {
                foods.Add(false);
            }
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
