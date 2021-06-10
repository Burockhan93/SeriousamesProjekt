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
    }

    public static void initGame()
    {
        remainingLife = MAX_LIFE;
        foodPointer = 0;
        StaticClass.score = 0;
        itemPointer = 0;
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
            
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            StaticClass.runGame = false;
            SceneManager.LoadScene("EndScreen");
        }

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
}
