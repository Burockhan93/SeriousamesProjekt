using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{


    public Text remainingLifeText;
    public Text foodText;
    public Text scoreText;
    public AdvancedFood[] food;
    public FruitPool fruitPool;
    public GameObject panel;

    public static int itemPointer { get; private set; }

    private static int foodPointer = 0;
    //TODO change to less life points
    public const int MAX_LIFE = 5;
    public static int remainingLife = 0;

    private Sprite[] itemImage;



    // Start is called before the first frame update
    void Start()
    {
        itemPointer = 0;
        initGame();
        remainingLifeText.text = remainingLife.ToString();

        //changeFood(0);

        PlayerControl.onScrollInput.AddListener(changeFoodNew);

        int ctr = 0;
        foreach (var item in StaticClass.food)
        {
            if (item.active)
            {
                ctr += 1;
            }
        }

        itemImage = new Sprite[ctr];
        Debug.Log("num of food" + ctr);
        ctr = 0;
        foreach (var item in StaticClass.food)
        {
            if (item.active)
            {
                itemImage[ctr] = item.symbol;
                ctr += 1;
            }
        }

        // itemImage[0] = food[0].GetComponent<AdvancedFood>().symbol;
        // itemImage[1] = food[1].GetComponent<AdvancedFood>().symbol;
        // itemImage[2] = food[2].GetComponent<AdvancedFood>().symbol;
        // itemImage[3] = food[3].GetComponent<AdvancedFood>().symbol;
        // itemImage[4] = food[4].GetComponent<AdvancedFood>().symbol;
    }

    public static void initGame()
    {
        remainingLife = MAX_LIFE;
        foodPointer = 0;
        StaticClass.score = 0;
        itemPointer = 0;

        //for (var i = 0; i < AnimalSpawner.animals.Count; i++)
        //{
        //    Destroy(AnimalSpawner.animals[i]);
        //}
        //AnimalSpawner.animals = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!StaticClass.runGame)
        {
            return;
        }

        //increase score by time
        StaticClass.score += Time.deltaTime;
        scoreText.text = Mathf.Round(StaticClass.score).ToString();

        //check, if the player is dead
        if (remainingLife > 0)
        {
            remainingLifeText.text = remainingLife.ToString();
        }
        else
        {
            Debug.Log("0 remaining life -> end game.");
            // Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            StaticClass.runGame = false;
            SceneManager.LoadScene("EndScreen");
        }

        ////change selected item
        //if (Input.mouseScrollDelta.y != 0)
        //{
        //    Debug.Log("Scroll " + (int)Input.mouseScrollDelta.y);
        //    changeFood((int)Input.mouseScrollDelta.y);
        //}

    }
    void changeFoodNew(float f)
    {

        Debug.Log("item:  " + itemPointer);

        if (f > 0 && itemPointer < itemImage.Length - 1)
        {
            itemPointer++;

        }
        else if (f < 0 && itemPointer > 0)
        {
            itemPointer--;

        }

        panel.GetComponent<Image>().sprite = itemImage[itemPointer];
        
    }


    //public void changeFood(int direction)
    //{
    //    //modulo to scroll up/down
    //    foodPointer = mod(foodPointer + direction, food.Length);
    //    Debug.Log("Länge " + food.Length + "; pointer " + foodPointer);

    //    //change food
    //    selectedFood = food[foodPointer];

    //    //change the food image
    //    //foodImage.MeshRenderer.Materials = selectedFood.Material;
    //    //foodImage.GetComponent<MeshRenderer>().material = selectedFood.GetComponent<MeshRenderer>().sharedMaterial;
    //    foodText.text = selectedFood.name;

    //}

    //int mod(int a, int b)
    //{
    //    int r = a % b;
    //    return r < 0 ? r + b : r;
    //}

}
