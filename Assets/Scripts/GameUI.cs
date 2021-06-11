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
    public const int MAX_LIFE = 5;
    public static int remainingLife = 0;
    private static bool initUi = false;
    private static Sprite[] itemImage;

    // Start is called before the first frame update
    void Start()
    {
        itemPointer = 0;
        initGame();
        remainingLifeText.text = remainingLife.ToString();

        //scroll listener to change the item
        PlayerControl.onScrollInput.AddListener(changeFoodNew);
    }

    public static void initGame()
    {
        //reset the game
        remainingLife = MAX_LIFE;
        foodPointer = 0;
        StaticClass.score = 0;
        itemPointer = 0;

        //count the selected items
        int ctr = 0;
        foreach (var item in StaticClass.food)
        {
            if (item.active)
            {
                ctr += 1;
            }
        }

        //set sprites for the food
        itemImage = new Sprite[ctr];
        Debug.Log("Number of selected different food: " + ctr);
        ctr = 0;
        foreach (var item in StaticClass.food)
        {
            if (item.active)
            {
                //set the sprite reference
                itemImage[ctr] = item.symbol;
                ctr += 1;
            }
        }
        initUi = false;
    }

    // Update is called once per frame
    void Update()
    {
        //update the UI only if the player read the instructions
        if (!StaticClass.runGame)
        {
            return;
        }

        if (!initUi)
        {
            //update visible sprite for the first time
            panel.GetComponent<Image>().sprite = itemImage[itemPointer];
            initUi = true;
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
            Debug.Log("No remaining life -> end game.");

            //release the cursor to select buttons
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            StaticClass.runGame = false;

            //navigate to the end screen
            SceneManager.LoadScene("EndScreen");
        }

    }
    void changeFoodNew(float f)
    {
        //change selected food item
        Debug.Log("item: " + itemPointer);

        if (f > 0 && itemPointer < itemImage.Length - 1)
        {
            itemPointer++;
        }
        else if (f < 0 && itemPointer > 0)
        {
            itemPointer--;
        }

        //update visible sprite
        panel.GetComponent<Image>().sprite = itemImage[itemPointer];
    }
}
