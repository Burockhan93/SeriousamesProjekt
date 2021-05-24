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
    public GameObject[] food;

    public static GameObject selectedFood;
    private static int foodPointer = 0;
    //TODO change to less life points
    public const int MAX_LIFE = 1;
    public static int remainingLife = 0;


    // Start is called before the first frame update
    void Start()
    {
        initGame();
        remainingLifeText.text = remainingLife.ToString();

        changeFood(0);
    }

    public static void initGame(){
        remainingLife = MAX_LIFE;
        foodPointer = 0;
        StaticClass.score = 0;

        for (var i = 0; i < AnimalSpawner.animals.Count; i++)
        {
            Destroy(AnimalSpawner.animals[i]);
        }
        AnimalSpawner.animals = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
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
            SceneManager.LoadScene("EndScreen");
        }

        //change selected item
        if (Input.mouseScrollDelta.y != 0)
        {
            Debug.Log("Scroll " + (int)Input.mouseScrollDelta.y);
            changeFood((int)Input.mouseScrollDelta.y);
        }

    }


    public void changeFood(int direction)
    {
        //modulo to scroll up/down
        foodPointer = mod(foodPointer + direction, food.Length);
        Debug.Log("Länge " + food.Length + "; pointer " + foodPointer);

        //change food
        selectedFood = food[foodPointer];

        //change the food image
        //foodImage.MeshRenderer.Materials = selectedFood.Material;
        //foodImage.GetComponent<MeshRenderer>().material = selectedFood.GetComponent<MeshRenderer>().sharedMaterial;
        foodText.text = selectedFood.name;

    }

    int mod(int a, int b)
    {
        int r = a % b;
        return r < 0 ? r + b : r;
    }

}
